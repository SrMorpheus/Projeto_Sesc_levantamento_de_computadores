using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Data.VO
{

    
    public class SetorVO
    {

        [JsonPropertyName("Code")]
        public int IdSetor { get; set; }


        [JsonPropertyName("Nome")]
        public string NomeSetor { get; set; }
        

    }
}
