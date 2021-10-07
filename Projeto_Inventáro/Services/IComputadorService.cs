using Projeto_Inventáro.Models;
using System.Collections.Generic;

namespace Projeto_Inventáro.Services.Implementations
{
    interface IComputadorService
    {


        Computador Create(Computador computador);

        Computador FindById(int id);

        List<Computador> FindAll();
        Computador Update(Computador computador);

        void Delete(int id);






    }
}
