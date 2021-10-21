using Projeto_Inventáro.Data.Converter.Contract;
using Projeto_Inventáro.Data.VO;
using Projeto_Inventáro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Data.Converter.Implementation
{
    public class EquipamentoConverter : IEquipamento<EquipamentoVO, Equipamento>, IEquipamento<Equipamento, EquipamentoVO>
    {
        public EquipamentoVO Parse(Equipamento origin)
        {
            if (origin == null) return null;

            return new EquipamentoVO
            {
                IdEquipamento = origin.IdEquipamento,

                NomeEquipamento = origin.NomeEquipamento

            };

        }

        public Equipamento Parse(EquipamentoVO origin)
        {

            if (origin == null) return null;

            return new Equipamento
            {
                IdEquipamento = origin.IdEquipamento,

                NomeEquipamento = origin.NomeEquipamento

            };

        }

        public List<EquipamentoVO> Parse(List<Equipamento> origin)
        {

            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();

        }

 

        public List<Equipamento> Parse(List<EquipamentoVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
