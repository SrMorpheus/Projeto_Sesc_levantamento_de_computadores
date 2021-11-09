using Projeto_Inventáro.Models;
using System.Collections.Generic;

namespace Projeto_Inventáro.Repository
{
    public interface IComputadorRepository
    {


        Computador Create(Computador computador);

        Computador FindById(int id);

        List<Computador> FindAll();

        Computador Update(Computador computador);

        void Delete(int id);

        bool Exists(int id);

        List<Computador> EquipamentoPesquisar(int id);

        List<Computador> ModeloPesquisar(int id);

        List<Computador> SetorPesquisar(int id);


        List<Computador> FindByName(string nomeComputador);

        List<Computador> FindByIp(string ip);


        List<Computador> FindWithPagedSearch(string query);


        int GetCount(string query);





    }
}
