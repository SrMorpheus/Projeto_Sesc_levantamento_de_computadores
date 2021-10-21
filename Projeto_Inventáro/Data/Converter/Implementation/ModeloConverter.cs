using Projeto_Inventáro.Data.Converter.Contract;
using Projeto_Inventáro.Data.VO;
using Projeto_Inventáro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Data.Converter.Implementation
{
    public class ModeloConverter : IModelo<ModeloVO, Modelo>, IModelo<Modelo, ModeloVO>

    {
        public Modelo Parse(ModeloVO origin)
        {


            if (origin == null) return null;
            return new Modelo
            {
                IdModelo = origin.IdModelo,

                NomeModelo = origin.NomeModelo

            };

        }


        public ModeloVO Parse(Modelo origin)
        {

            if (origin == null) return null;
            return new ModeloVO
            {
                IdModelo = origin.IdModelo,

                NomeModelo = origin.NomeModelo

            };

        }

        public List<ModeloVO> Parse(List<Modelo> origin)
        {

            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();

        }

        public List<Modelo> Parse(List<ModeloVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

    }
}
