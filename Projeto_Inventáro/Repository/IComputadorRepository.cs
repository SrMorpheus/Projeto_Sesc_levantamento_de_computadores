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




    }
}
