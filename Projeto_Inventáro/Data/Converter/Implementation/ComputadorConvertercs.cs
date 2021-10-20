using Projeto_Inventáro.Data.Converter.Contract;
using Projeto_Inventáro.Data.VO;
using Projeto_Inventáro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Data.Converter.Implementation
{
    public class ComputadorConvertercs : IComputador<ComputadorVO, Computador>, IComputador<Computador, ComputadorVO>
    
    {
        public Computador Parse(ComputadorVO origin)
        {

            if (origin == null) return null;
            return new Computador
            {
                IdComputador = origin.IdComputador,

                NomeComputador = origin.NomeComputador,

                Modelos = origin.Modelos,

                ModeloId = origin.ModeloId,

                Equipamentos = origin.Equipamentos,

                EquipamentoId = origin.EquipamentoId,

                EnderecoIp = origin.EnderecoIp,

                PatrimonioGabinete = origin.PatrimonioGabinete,

                PatrimonioMonitor = origin.PatrimonioMonitor,

                Ano = origin.Ano,

                Internet = origin.Internet,

                Setores = origin.Setores,

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

                Modelos = origin.Modelos,

                ModeloId = origin.ModeloId,

                Equipamentos = origin.Equipamentos,

                EquipamentoId = origin.EquipamentoId,

                EnderecoIp = origin.EnderecoIp,

                PatrimonioGabinete = origin.PatrimonioGabinete,

                PatrimonioMonitor = origin.PatrimonioMonitor,

                Ano = origin.Ano,

                Internet = origin.Internet,

                Setores = origin.Setores,

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
