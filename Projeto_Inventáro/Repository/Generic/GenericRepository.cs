using Microsoft.EntityFrameworkCore;
using Projeto_Inventáro.Models.Base;
using Projeto_Inventáro.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext _context;

        private DbSet<T> _dataset;

        public GenericRepository(MySQLContext context)
        {

            _context = context;

            _dataset = _context.Set<T>();


        }


        public T Create(T item)
        {


            try
            {

                _dataset.Add(item);

                _context.SaveChanges();


            }
            catch (Exception ex)
            {
                throw ex;

            }


            return item;

        }

        public void Delete(int id)
        {

            var result = _dataset.SingleOrDefault(M => M.Id.Equals(id));

            if (result != null)
            {

                try
                {

                    _dataset.Remove(result);

                    _context.SaveChanges();

                }
                catch (Exception)
                {
                    throw;
                }

            }


        }

        public bool Exists(int id)
        {


            return _dataset.Any(M => M.Id.Equals(id));
        }



        public List<T> FindAll()
        {

        return    _dataset.ToList();

        }

        public T FindById(int id)
        {
            return _dataset.SingleOrDefault(I => I.Id.Equals(id));
            

        }

        public T Update(T item)
        {

           


            var result = _dataset.SingleOrDefault(M => M.Id.Equals(item.Id));


            if (result != null)
            {

                try
                {

                    _context.Entry(result).CurrentValues.SetValues(item);

                    _context.SaveChanges();


                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;

                }



            }else
            {
                return null;

            }






        }
    }
}
