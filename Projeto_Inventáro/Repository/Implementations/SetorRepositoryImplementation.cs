using Microsoft.EntityFrameworkCore;
using Projeto_Inventáro.Models;
using Projeto_Inventáro.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Repository.Implementations
{
    public class SetorRepositoryImplementation : ISetorRepository
    {

         private MySQLContext _context;

        public SetorRepositoryImplementation(MySQLContext context)
        {

            _context = context;
        }


        public Setor Create(Setor setor)
        {

            try
            {
                _context.Add(setor);

                _context.SaveChanges();


            }
            catch( Exception ex  )
            {
                throw ex;

            }

            return setor;

        }

        public void Delete(int id)
        {

            var result = _context.Setors.SingleOrDefault(S => S.IdSetor.Equals(id));


            if(result != null)
            {


                try
                {

                    _context.Setors.Remove(result);

                    _context.SaveChanges();


                }
                catch ( Exception)
                {
                    throw;
                }


            }


        }


      public  List<Setor> FindAll()
        {


            return _context.Setors.ToList();

        }


        public bool Exists(int id)
        {

            return _context.Setors.Any(S => S.IdSetor.Equals(id));

        }

        public Setor FindById(int id)
        {

            return _context.Setors.SingleOrDefault(S => S.IdSetor.Equals(id));

        }

        public Setor Update(Setor setor)
        {


            if (!Exists(setor.IdSetor)) return new Setor();

            var result = _context.Setors.SingleOrDefault( S => S.IdSetor.Equals(setor.IdSetor));


            if (result != null)
            {

                try
                {
                    _context.Entry(result).CurrentValues.SetValues(setor);

                    _context.SaveChanges();

                }
                catch ( Exception ex)
                {

                    throw ex;

                }


            }


            return setor;


        }
    }
}
