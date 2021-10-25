using Projeto_Inventáro.Data.Converter.Implementation;
using Projeto_Inventáro.Data.VO;
using Projeto_Inventáro.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Services.Implementations
{
    public class ModeloServiceImplementation : IModeloService
    {


        private readonly IModeloRepositorycs _modeloRepository;

        private readonly ModeloConverter _converter;



        public ModeloServiceImplementation( IModeloRepositorycs modeloRepository)
        {
            _modeloRepository = modeloRepository;

            _converter = new ModeloConverter();

        }



        public ModeloVO Create(ModeloVO modeloVO)
        {

            var modelo = _converter.Parse(modeloVO);

            modelo = _modeloRepository.Create(modelo);

            return _converter.Parse(modelo);

        }

        public void Delete(int id)
        {

            _modeloRepository.Delete(id);

        }

        public List<ModeloVO> FindAll()
        {

            return _converter.Parse(_modeloRepository.FindAll());


        }

        public ModeloVO FindById(int id)
        {

            return _converter.Parse(_modeloRepository.FindById(id));

        }

        public ModeloVO Update(ModeloVO modeloVO)
        {

            var modelo = _converter.Parse(modeloVO);

            modelo = _modeloRepository.Update(modelo);

            return _converter.Parse(modelo);


        }
    }
}
