using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Projeto_Inventáro.Models;


namespace Projeto_Inventáro.Services
{
    interface IUsuarioServicecs
    {



        Usuario  Create(Usuario usuario);

        Usuario FindById(int id);

        List<Usuario> FindAll();
       Usuario Update(Usuario usuario);

        void Delete(int id);







    }
}
