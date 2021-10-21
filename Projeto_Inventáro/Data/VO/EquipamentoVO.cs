using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Data.VO
{
    
    public class EquipamentoVO
    {

        [JsonPropertyName("Code")]
        public int IdEquipamento { get; set; }

        [JsonPropertyName("Nome")]
        public string NomeEquipamento { get; set; }





    }
}
