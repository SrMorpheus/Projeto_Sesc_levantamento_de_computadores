using Projeto_Inventáro.Hypermedia;
using Projeto_Inventáro.Hypermedia.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Data.VO
{

    
    public class SetorVO : ISupportHyperMedia
    {

        [JsonPropertyName("Code")]
        public int IdSetor { get; set; }


        [JsonPropertyName("Nome")]
        public string NomeSetor { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
