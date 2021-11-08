using Projeto_Inventáro.Configurations;
using Projeto_Inventáro.Data.VO;
using Projeto_Inventáro.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Services.Implementations
{
    public class LoginServiceImplementation : ILoginService
    {

        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";

        private TokenConfiguration _configuration;

        private ILoginRepository _repository;

        private readonly ITokenService _tokenService;


        public LoginServiceImplementation(TokenConfiguration configuration, ILoginRepository repository, ITokenService tokenService)
        {

            _configuration = configuration;

            _repository = repository;

            _tokenService = tokenService;

        }

        public TokenVO ValidateCredentials(LoginVO login)
        {

            var user = _repository.ValidateCredentials(login);

            if (user == null) return null;

            var claims = new List<Claim>
            {

                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),

                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)

            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();


            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTibe = DateTime.Now.AddDays(_configuration.DaysToExpiry);

            _repository.RefreshLoginInfo(user);


            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);


            return new TokenVO
                (

                true,

                createDate.ToString(DATE_FORMAT),

                expirationDate.ToString(DATE_FORMAT),

                accessToken,

                refreshToken

                );



        }

        public TokenVO ValidateCredentials(TokenVO token)
        {

            var accessToken = token.AccessToken;
            var refreshToken = token.RefreshToken;



            var pricncipal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
            var username = pricncipal.Identity.Name;


            var user = _repository.ValidateCredentials(username);



            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTibe <= DateTime.Now) return null;


            accessToken = _tokenService.GenerateAccessToken(pricncipal.Claims);

            refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;


            _repository.RefreshLoginInfo(user);


            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);


            return new TokenVO
                (

                true,

                createDate.ToString(DATE_FORMAT),

                expirationDate.ToString(DATE_FORMAT),

                accessToken,

                refreshToken

                );

        }

        public bool RevokeToken(string username)
        {

            return _repository.RevokeToken(username);

        }
    }
}
