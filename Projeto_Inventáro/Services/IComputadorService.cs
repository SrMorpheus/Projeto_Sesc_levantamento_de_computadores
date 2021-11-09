using Projeto_Inventáro.Data.VO;
using Projeto_Inventáro.Hypermedia.Utils;
using Projeto_Inventáro.Models;
using System.Collections.Generic;

namespace Projeto_Inventáro.Services.Implementations
{
    public interface IComputadorService
    {


        ComputadorVO Create(ComputadorVO computador);

        ComputadorVO FindById(int id);

        List<ComputadorVO> FindAll();


        PagedSearchVO<ComputadorVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);

        ComputadorVO Update(ComputadorVO computador);

        void Delete(int id);

        List<ComputadorVO> EquipamentoPesquisar(int id);

        List<ComputadorVO> ModeloPesquisar(int id);

        List<ComputadorVO> SetorPesquisar(int id);


        List<ComputadorVO> FindByName(string nomeComputador);

        List<ComputadorVO> FindByIp(string ip);

    }
}
