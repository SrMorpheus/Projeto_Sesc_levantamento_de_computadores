using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Projeto_Inventáro.Models;


namespace Projeto_Inventáro.Repository
{
   public interface IUsuarioRepository


    {
        


        Usuario  Create(Usuario usuario);

        Usuario FindById(int id);

        List<Usuario> FindAll();
        List<Usuario> SetorPesquisar(int id);

        List<Usuario> ComputadorPesquisar(int id);

        List<Usuario> FindByName(string nome);

        List<Usuario> FindWithPagedSearch(string query);


        int GetCount(string query);



        Usuario Update(Usuario usuario);

        void Delete(int id);

        bool Exists(int id);






    }
}
