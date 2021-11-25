using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Inventáro.Data.VO;
using Projeto_Inventáro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private ILoginService _loginService;


        public AuthController(ILoginService loginService)
        {

            _loginService = loginService;

        }



        /// <summary>
        /// Lista os itens da To-do list.
        /// </summary>
        /// <returns>Os itens da To-do list</returns>
        /// <response code="200">Returna os itens da To-do list cadastrados</response>
     
        [HttpPost]

        [Route("signin")]
        public IActionResult Signin ([FromBody] LoginVO loginVO)
        {

            if (loginVO == null) return BadRequest("Ivalid client request");

            var token = _loginService.ValidateCredentials(loginVO);

            if (token == null) return Unauthorized();

            return Ok(token);


        }

        [HttpPost]
        [Route("refresh")]

        public IActionResult Refresh([FromBody] TokenVO tokenVo)
        {

            if (tokenVo is null) return BadRequest("Ivalid client request");

            var token = _loginService.ValidateCredentials(tokenVo);

            if (token == null) return BadRequest("Ivalid client request");

            return Ok(token);


        }

        [HttpGet]
        [Route("revoke")]
        [Authorize("Bearer")]

        public IActionResult Revoke()
        {

            var username = User.Identity.Name;

            var result = _loginService.RevokeToken(username);

            if (!result) return BadRequest("Ivalid client request");

            return NoContent();

        }







    }
}
