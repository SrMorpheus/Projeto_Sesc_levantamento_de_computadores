using Projeto_Inventáro.Models;
using Projeto_Inventáro.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Repository.Implementations
{
    public class EquipamentoRepositoryImplementationcs : IEquipamentoRepository
    {

        private MySQLContext _context;

        public EquipamentoRepositoryImplementationcs( MySQLContext context)
        {

            _context = context;

        }


        public Equipamento Create(Equipamento equipamento)
        {


            try
            {

                _context.Add(equipamento);

                _context.SaveChanges();


            }
            catch (Exception ex)
            {

                throw ex;
            }


            return equipamento;

        }

        public void Delete(int id)
        {

            var result = _context.Equipamentos.SingleOrDefault( E=> E.IdEquipamento.Equals(id));


            if(result !=null)
            {
                try
                {
                    _context.Equipamentos.Remove(result);

                    _context.SaveChanges();

                }
                catch ( Exception)
                {
                    throw;

                }




            }



        }

        public bool Exists(int id)
        {

            return _context.Equipamentos.Any(E => E.IdEquipamento.Equals(id));

        }

        public List<Equipamento> FindAll()
        {


            return _context.Equipamentos.ToList();
            

        }

        public Equipamento FindById(int id)
        {

          return  _context.Equipamentos.SingleOrDefault(E => E.IdEquipamento.Equals(id));

        }

        public Equipamento Update(Equipamento equipamento)
        {

            if (!Exists(equipamento.IdEquipamento)) return new Equipamento();


            var result = _context.Equipamentos.SingleOrDefault(E => E.IdEquipamento.Equals(equipamento.IdEquipamento));


            if (result != null)
            {
                try
                {

                    _context.Entry(result).CurrentValues.SetValues(equipamento);

                    _context.SaveChanges();


                }
                catch (Exception ex)
                {
                    throw ex;

                }




            }

            return equipamento;




        }
    }
}
