using Projeto_Inventáro.Models;
using Projeto_Inventáro.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Repository.Implementations
{
    public class ModeloRepositoryImplementation : IModeloRepositorycs


    {


        private MySQLContext _context;

        public ModeloRepositoryImplementation(MySQLContext context)
        {

            _context = context;


        }


        public Modelo Create(Modelo modelo)
        {


            try
            
            {
                _context.Add(modelo);


                _context.SaveChanges();

            }
            catch ( Exception ex)
            {
                throw ex;


            }

            return modelo;

        }

        public void Delete(int id)
        {


            var result = _context.Modelos.SingleOrDefault(M => M.IdModelo.Equals(id));


            if(result != null)
            {

                try
                {

                    _context.Modelos.Remove(result);

                    _context.SaveChanges();




                }catch (Exception)
                {

                    throw;
                }
                


            }


        }

        public bool Exists(int id)
        {

            return _context.Modelos.Any(M => M.IdModelo.Equals(id));

        }

        public List<Modelo> FindAll()
        {

            return _context.Modelos.ToList();


        }

        public Modelo FindById(int id)
        {

            return _context.Modelos.SingleOrDefault(M => M.IdModelo.Equals(id));

        }

        public Modelo Update(Modelo modelo)
        {

            if (!Exists(modelo.IdModelo)) return new Modelo();


            var result = _context.Modelos.SingleOrDefault(M => M.IdModelo.Equals(modelo.IdModelo));


            if (result != null)
            {


                try
                {
                    _context.Entry(result).CurrentValues.SetValues(modelo);

                    _context.SaveChanges();



                }
                catch ( Exception ex)
                {
                    throw ex;

                }



            }

            return modelo;
        }
    }
}
