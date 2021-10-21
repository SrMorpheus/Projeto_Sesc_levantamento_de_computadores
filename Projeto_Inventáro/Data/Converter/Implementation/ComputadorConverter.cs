using Projeto_Inventáro.Data.Converter.Contract;
using Projeto_Inventáro.Data.VO;
using Projeto_Inventáro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Data.Converter.Implementation
{
    public class ComputadorConverter : IComputador<ComputadorVO, Computador>, IComputador<Computador, ComputadorVO>
    
    {
        private readonly SetorConverter _setorConverter;

        private readonly EquipamentoConverter _equipamentoConverter;

        private readonly ModeloConverter _modeloConverter;

        public ComputadorConverter()
        {
            _setorConverter = new SetorConverter();

            _equipamentoConverter = new EquipamentoConverter();

            _modeloConverter = new ModeloConverter();

        }

        public Computador Parse(ComputadorVO origin)
        {

            if (origin == null) return null;
            return new Computador
            {
                IdComputador = origin.IdComputador,

                NomeComputador = origin.NomeComputador,

                Modelos = _modeloConverter.Parse (origin.ModelosVO),

                ModeloId = origin.ModeloId,

                Equipamentos = _equipamentoConverter.Parse(origin.EquipamentosVO),

                EquipamentoId = origin.EquipamentoId,

                EnderecoIp = origin.EnderecoIp,

                PatrimonioGabinete = origin.PatrimonioGabinete,

                PatrimonioMonitor = origin.PatrimonioMonitor,

                Ano = origin.Ano,

                Internet = origin.Internet,

                Setores = _setorConverter.Parse(origin.SetoresVO),

               SetorId = origin.SetorId


            };


        }

      

        public ComputadorVO Parse(Computador origin)
        {
            if (origin == null) return null;
            return new ComputadorVO
            {
                IdComputador = origin.IdComputador,

                NomeComputador = origin.NomeComputador,

                ModelosVO = _modeloConverter.Parse( origin.Modelos),

                ModeloId = origin.ModeloId,

                EquipamentosVO = _equipamentoConverter.Parse( origin.Equipamentos),

                EquipamentoId = origin.EquipamentoId,

                EnderecoIp = origin.EnderecoIp,

                PatrimonioGabinete = origin.PatrimonioGabinete,

                PatrimonioMonitor = origin.PatrimonioMonitor,

                Ano = origin.Ano,

                Internet = origin.Internet,

                SetoresVO = _setorConverter.Parse( origin.Setores),

                SetorId = origin.SetorId


            };



        }

        public List<ComputadorVO> Parse(List<Computador> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();

        }

            public List<Computador> Parse(List<ComputadorVO> origin)
        {

            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList(); 


        }
    }
}
