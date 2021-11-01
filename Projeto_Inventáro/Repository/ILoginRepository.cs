using Projeto_Inventáro.Data.VO;
using Projeto_Inventáro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Repository
{
    public interface ILoginRepository
    {

        Login ValidateCredentials(LoginVO login);

    }
}
