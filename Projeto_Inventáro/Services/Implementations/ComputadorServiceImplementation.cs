using Projeto_Inventáro.Models;
using Projeto_Inventáro.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Services.Implementations
{
    public class ComputadorServiceImplementation : IComputadorService
    {



        
        private  MySQLContext  _context;



        public ComputadorServiceImplementation( MySQLContext context)
        {
            _context = context;

        }
        public Computador Create(Computador computador)
        {

            try
            {

                _context.Add(computador);

                _context.SaveChanges();


            }
            catch (Exception ex)
            {
                throw ex;

            }


            return computador;


        }

        public void Delete(int id)
        {


            var result = _context.Computadors.SingleOrDefault(M => M.IdComputador.Equals(id));

            if(result != null)
            {

                try
                {

                    _context.Computadors.Remove(result);

                    _context.SaveChanges();

                }
                catch (Exception)
                {
                    throw;
                }

            }

        }

        public List<Computador> FindAll()
        {

            return _context.Computadors.ToList();

        }

       



        public Computador FindById(int id)
        {


            return _context.Computadors.SingleOrDefault(M => M.IdComputador.Equals(id));

        }

        public Computador Update(Computador computador)
        {
            if (!Exists(computador.IdComputador)) return new Computador();


            var result = _context.Computadors.SingleOrDefault(M => M.IdComputador.Equals(computador.IdComputador));


            if (result != null)
            {

                try
                {

                    _context.Entry(result).CurrentValues.SetValues(computador);

                    _context.SaveChanges();


                }
                catch (Exception ex)
                {
                    throw ex;

                }



            }




            return computador;


        }

        private bool Exists(int id)
        {


            return _context.Computadors.Any(M => M.IdComputador.Equals(id));
    }
    }
}
