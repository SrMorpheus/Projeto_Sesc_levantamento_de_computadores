using Projeto_Inventáro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Services.Implementations
{
    public class ComputadorServiceImplementation : IComputadorService
    {

        private volatile int Count;
        public Computador Create(Computador computador)
        {

            return computador;


        }

        public void Delete(int id)
        {
            

        }

        public List<Computador> FindAll()
        {

            List<Computador> Computadors =  new List<Computador>();

            for(int i = 0; i < 8; i++)
            {


                Computador computador = MockComputador(i);

                Computadors.Add(computador);

            }


            return Computadors;

        }

        private Computador MockComputador(int i)
        {

            return new Computador
            {
                IdComputador = IncrementAndGet(),

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

        private int IncrementAndGet()
        {
            return Interlocked.Increment(ref Count);
        }

        public Computador FindById(int id)
        {

            return new Computador
            {
                IdComputador = IncrementAndGet(),


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
