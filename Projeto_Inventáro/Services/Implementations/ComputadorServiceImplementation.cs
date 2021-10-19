using Projeto_Inventáro.Models;
using Projeto_Inventáro.Models.Context;
using Projeto_Inventáro.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Services.Implementations
{
    public class ComputadorServiceImplementation : IComputadorService
    {




        private readonly IComputadorRepository _computadorRepository;



        public ComputadorServiceImplementation(IComputadorRepository computadorRepository)
        {

            _computadorRepository = computadorRepository;

        }
        public Computador Create(Computador computador)
        {

          


            return _computadorRepository.Create(computador);


        }

        public void Delete(int id)
        {


            _computadorRepository.Delete(id);

        }

        public List<Computador> FindAll()
        {

            return _computadorRepository.FindAll();

        }

       



        public Computador FindById(int id)
        {


            return _computadorRepository.FindById(id);

        }

        public Computador Update(Computador computador)
        {

            return _computadorRepository.Update(computador);


        }

   
    }
}
