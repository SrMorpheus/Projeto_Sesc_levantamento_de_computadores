using Projeto_Inventáro.Data.VO;
using Projeto_Inventáro.Models;
using System.Collections.Generic;

namespace Projeto_Inventáro.Services.Implementations
{
    public interface IComputadorService
    {


        ComputadorVO Create(ComputadorVO computador);

        ComputadorVO FindById(int id);

        List<ComputadorVO> FindAll();

        ComputadorVO Update(ComputadorVO computador);

        void Delete(int id);






    }
}
