using Projeto_Inventáro.Data.Converter.Implementation;
using Projeto_Inventáro.Data.VO;
using Projeto_Inventáro.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Services.Implementations
{
    public class EquipamentoServiceImplementation : IEquipamentoService
    {

        private readonly IEquipamentoRepository _equipamentoRepository;

        private readonly EquipamentoConverter _converter;



        public EquipamentoServiceImplementation( IEquipamentoRepository equipamentoRepository )
        {

            _equipamentoRepository = equipamentoRepository;

            _converter = new EquipamentoConverter();

        }


        public EquipamentoVO Create(EquipamentoVO equipamentoVO)
        {

            var equipamento = _converter.Parse(equipamentoVO);

            equipamento = _equipamentoRepository.Create(equipamento);

            return _converter.Parse(equipamento);


        }

        public void Delete(int id)
        {

            _equipamentoRepository.Delete(id);

        }

        public List<EquipamentoVO> FindAll()
        {

            return _converter.Parse(_equipamentoRepository.FindAll());

        }

        public EquipamentoVO FindById(int id)
        {


            return _converter.Parse(_equipamentoRepository.FindById(id));
        }

        public EquipamentoVO Update(EquipamentoVO equipamentoVO)
        {


            var equipamento = _converter.Parse(equipamentoVO);

            equipamento = _equipamentoRepository.Update(equipamento);

            return _converter.Parse(equipamento);


        }
    }
}
