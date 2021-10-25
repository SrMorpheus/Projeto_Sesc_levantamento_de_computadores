using Projeto_Inventáro.Data.Converter.Implementation;
using Projeto_Inventáro.Data.VO;
using Projeto_Inventáro.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Services.Implementations
{
    public class SetorServiceImplementation : ISetorService
    {


        private readonly ISetorRepository _setorRepository;


        private readonly SetorConverter _converter;


        public SetorServiceImplementation(ISetorRepository setorRepository)
        {

            _setorRepository = setorRepository;

            _converter = new SetorConverter();



        }


        public SetorVO Create(SetorVO setorVO)
        {


            var setor = _converter.Parse(setorVO);


            setor = _setorRepository.Create(setor);


            return _converter.Parse(setor);




        }

        public void Delete(int id)
        {


            _setorRepository.Delete(id);

        }

        public List<SetorVO> FindAll()
        {

            return _converter.Parse(_setorRepository.FindAll());

        }

        public SetorVO FindById(int id)
        {

            return _converter.Parse(_setorRepository.FindById(id));

        }

        public SetorVO Update(SetorVO setorVO)
        {

            var setor = _converter.Parse(setorVO);

            setor = _setorRepository.Update(setor);

            return _converter.Parse(setor);

        }
    }
}
