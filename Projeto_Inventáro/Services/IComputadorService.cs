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

        List<ComputadorVO> EquipamentoPesquisar(int id);

        List<ComputadorVO> ModeloPesquisar(int id);

        List<ComputadorVO> SetorPesquisar(int id);




    }
}
