using Projeto_Inventáro.Models;
using Projeto_Inventáro.Models.Base;
using System.Collections.Generic;

namespace Projeto_Inventáro.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {


        T Create(T item);

        T FindById(int id);

        List<T> FindAll();

        T Update(T item);

        void Delete(int id);

        bool Exists(int id);




    }
}
