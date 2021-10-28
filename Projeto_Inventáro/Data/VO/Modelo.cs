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
  
    public class ModeloVO :ISupportHyperMedia
    {
        [JsonPropertyName("Code")]
        public int IdModelo { get; set; }


        [JsonPropertyName("Nome")]
        public string NomeModelo { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}


