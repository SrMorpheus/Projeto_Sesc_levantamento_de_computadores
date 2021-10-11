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

            return computador;


        }

        public void Delete(int id)
        {
            

        }

        public List<Computador> FindAll()
        {

            return _context.Computadors.ToList();

        }

       



        public Computador FindById(int id)
        {

            return new Computador
            {
                IdComputador = 1,


                NomeComptador = "BRUNO",

                EnderecoIp = "190.120.2.115",

                ModeloId = 1,

                EquipamentoId = 1,

                PatrimonioMonitor = 1266,

                PatrimonioGabinete = 1958,

                Ano = 2019,

                Internet = true,

                SetorId = 1


            };

        }

        public Computador Update(Computador computador)
        {


            return computador;
        }
    }
}
