using Projeto_Inventáro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Data.VO
{



    public class ComputadorVO
    {


         [JsonPropertyName("Code")]
        public int IdComputador { get; set; }

        [Required]
        [JsonPropertyName("Nome")]
        public string NomeComputador { get; set; }


        [JsonPropertyName("Modelo")]
        public ModeloVO ModelosVO { get; set; }

        [Required]
        [JsonPropertyName("Code Modelo")]
        public int ModeloId { get; set; }


        [JsonPropertyName("Equipamento")]

        public EquipamentoVO EquipamentosVO { get; set; }

        
        [Required]
        [JsonPropertyName("Code Equipamento")]
        public int EquipamentoId { get; set; }


        [Required]
        [JsonPropertyName("IP")]
        public string EnderecoIp { get; set; }


        [JsonPropertyName("Patrimônio do  Monitor")]
        public int PatrimonioMonitor { get; set; }


        [Required]
        [JsonPropertyName("Patrimônio do Gabinete")]
        public int PatrimonioGabinete { get; set; }


        [Required]
        [JsonPropertyName("Ano de Aquisição")]
        public int Ano { get; set; }



        [JsonPropertyName("Liberação da Internet")]
        public bool Internet  {get; set ;}


        [Required]
        [JsonPropertyName("Code Setor")]
        public int SetorId { get; set; }


        [JsonPropertyName("Setor")]
        public SetorVO SetoresVO { get; set; }






    }
}
