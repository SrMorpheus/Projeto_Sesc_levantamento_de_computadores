using Projeto_Inventáro.Data.Converter.Implementation;
using Projeto_Inventáro.Data.VO;
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


        private readonly ComputadorConverter _converter;



        public ComputadorServiceImplementation(IComputadorRepository computadorRepository)
        {

            _computadorRepository = computadorRepository;

            _converter = new ComputadorConverter();

        }
        public ComputadorVO Create(ComputadorVO computador)
        {


            var computadorEntity = _converter.Parse(computador);

            computadorEntity = _computadorRepository.Create(computadorEntity);

            return _converter.Parse(computadorEntity);


        }
        public ComputadorVO Update(ComputadorVO computador)
        {

            var computadorEntity = _converter.Parse(computador);

            computadorEntity = _computadorRepository.Update(computadorEntity);

            return _converter.Parse(computadorEntity);



        }

        public void Delete(int id)
        {


            _computadorRepository.Delete(id);

        }

      

        public List<ComputadorVO> FindAll()
        {

            return _converter.Parse( _computadorRepository.FindAll());

        }

       



        public ComputadorVO FindById(int id)
        {


            return _converter.Parse (_computadorRepository.FindById(id));

        }

        public List<ComputadorVO> ModeloPesquisar(int id)


        {
            return _converter.Parse(_computadorRepository.ModeloPesquisar(id));


        }

        public List<ComputadorVO> SetorPesquisar(int id)
        {

            return _converter.Parse(_computadorRepository.SetorPesquisar(id));
        }

        public List<ComputadorVO> EquipamentoPesquisar(int id)
        {
            return _converter.Parse(_computadorRepository.EquipamentoPesquisar(id));

        }


    }
}
