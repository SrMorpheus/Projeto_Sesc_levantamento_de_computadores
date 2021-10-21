using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Data.VO
{
  
    public class ModeloVO
    {
        [JsonPropertyName("Code")]
        public int IdModelo { get; set; }


        [JsonPropertyName("Nome")]
        public string NomeModelo { get; set; }





    }
}


