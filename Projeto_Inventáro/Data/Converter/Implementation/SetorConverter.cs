using Projeto_Inventáro.Data.Converter.Contract;
using Projeto_Inventáro.Data.VO;
using Projeto_Inventáro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Data.Converter.Implementation
{
    public class SetorConverter : ISetor<SetorVO, Setor>, ISetor<Setor, SetorVO>
    {




        public SetorVO Parse(Setor origin)
        {



            if (origin == null) return null;
            return new SetorVO
            {
                IdSetor = origin.IdSetor,

                NomeSetor = origin.NomeSetor

            };


        }


        public Setor Parse(SetorVO origin)
        {


            if (origin == null) return null;
            return new Setor
            {
                IdSetor = origin.IdSetor,

                NomeSetor = origin.NomeSetor

            };


        }


        public List<SetorVO> Parse(List<Setor> origin)
        {

            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();

        }

        

        public List<Setor> Parse(List<SetorVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
