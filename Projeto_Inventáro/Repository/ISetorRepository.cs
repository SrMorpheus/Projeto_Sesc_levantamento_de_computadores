using Projeto_Inventáro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Repository
{
  public  interface ISetorRepository
    {



        Setor Create(Setor setor);

        Setor FindById(int id);

        List<Setor> FindAll();

        Setor Update(Setor setor);

        void Delete(int id);

        bool Exists(int id);




    }
}
