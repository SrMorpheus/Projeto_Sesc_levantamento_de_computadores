using Projeto_Inventáro.Data.VO;
using Projeto_Inventáro.Models;
using Projeto_Inventáro.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly MySQLContext _context;

        public LoginRepository( MySQLContext context)
        {

            _context = context;

        }

        public Login ValidateCredentials(LoginVO login )
        {

            var pass = ComputeHash(login.Password, new SHA256CryptoServiceProvider());

            return _context.Logins.FirstOrDefault(u => (u.UserName == login.UserName) && (u.Password == pass));

        }

        private string ComputeHash(string password, SHA256CryptoServiceProvider algoritm)
        {

            Byte[] inputBytes = Encoding.UTF8.GetBytes(password);

            Byte[] hashedBytes = algoritm.ComputeHash(inputBytes);


            return BitConverter.ToString(hashedBytes);



        }

        public Login RefreshLoginInfo( Login login)
        {


            if (!_context.Logins.Any(L => L.id.Equals(login.id))) return null;

            var result = _context.Logins.SingleOrDefault(L => L.id.Equals(login.id));

           if (result != null)
            {
                try{

                    _context.Entry(result).CurrentValues.SetValues(login);
                    _context.SaveChanges();
                    return result;


                }
                catch (Exception)
                {
                    throw;

                }

             
            }


            return result;



        }



    }
}
