using Projeto_Inventáro.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Services
{
   public interface ILoginService
    {


        TokenVO ValidateCredentials(LoginVO login);



    }
}
