using Microsoft.EntityFrameworkCore;
using Projeto_Inventáro.Models;
using Projeto_Inventáro.Models.Context;
using Projeto_Inventáro.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Repository
{
    public class ComputadorRepositoryImplementation : IComputadorRepository
    {



        
        private  MySQLContext  _context;



        public ComputadorRepositoryImplementation( MySQLContext context)
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

            var computador = _context.Computadors.Include(E => E.Equipamentos).Include(S => S.Setores).Include(M => M.Modelos);



            return computador.ToList();

        }

       



        public Computador FindById(int id)
        {

            var computador = _context.Computadors.Include(E => E.Equipamentos).Include(S => S.Setores).Include(M => M.Modelos).SingleOrDefault(M => M.IdComputador.Equals(id));
            ;



            return computador;

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

        public bool Exists(int id)
        {


            return _context.Computadors.Any(M => M.IdComputador.Equals(id));
    }

        public List<Computador> EquipamentoPesquisar(int id)
        {

            var computador = _context.Computadors.Include(E => E.Equipamentos).Include(S => S.Setores).Include(M => M.Modelos).AsNoTracking().Where(E => E.EquipamentoId == id);


                return computador.ToList();
        }

        public List<Computador> ModeloPesquisar(int id)
        {

            var computador = _context.Computadors.Include(E => E.Equipamentos).Include(S => S.Setores).Include(M => M.Modelos).AsNoTracking().Where(M => M.ModeloId == id);

            return computador.ToList();

        }

        public List<Computador> SetorPesquisar(int id )
        {

            var computador = _context.Computadors.Include(E => E.Equipamentos).Include(S => S.Setores).Include(M => M.Modelos).AsNoTracking().Where(S => S.SetorId == id);

            return computador.ToList();
        }
    }
}
