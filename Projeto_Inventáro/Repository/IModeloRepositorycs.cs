using Projeto_Inventáro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Repository
{
    public interface IModeloRepositorycs
    {



        Modelo Create(Modelo modelo);

        Modelo FindById(int id);


        Modelo Update(Modelo modelo);

        void Delete(int id);

        bool Exists(int id);

        List<Modelo> FindAll();


    }
}
