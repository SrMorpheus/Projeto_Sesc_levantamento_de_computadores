using Projeto_Inventáro.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Services
{
  public  interface ISetorService
    {


        SetorVO Create(SetorVO setorVO);

        SetorVO FindById(int id);

        List<SetorVO> FindAll();

        SetorVO Update(SetorVO setorVO);

        void Delete(int id);


    }
}
