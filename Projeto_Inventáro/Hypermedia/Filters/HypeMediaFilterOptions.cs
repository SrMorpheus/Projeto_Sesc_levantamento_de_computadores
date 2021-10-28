using Projeto_Inventáro.Hypermedia.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Hypermedia.Filters
{
    public class HypeMediaFilterOptions
    {


        public List<IResponseEnricher> ResponseEnrichers { get; set; } = new List<IResponseEnricher>();


    }
}
