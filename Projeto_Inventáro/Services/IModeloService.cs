using Projeto_Inventáro.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Services
{
    public interface IModeloService
    {



        ModeloVO Create(ModeloVO modeloVO);

        ModeloVO FindById(int id);

        List<ModeloVO> FindAll();

        ModeloVO Update(ModeloVO modeloVO);

        void Delete(int id);




    }
}
