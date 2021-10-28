using Projeto_Inventáro.Data.VO;
using Projeto_Inventáro.Hypermedia;
using Projeto_Inventáro.Hypermedia.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Models
{

    public class UsuarioVO : ISupportHyperMedia
    {

        [JsonPropertyName("Code")]
        public int IdUsuario { get; set; }


        [JsonPropertyName("Nome")]
        public string NomeUsuario { get; set; }

        [Required]
        [JsonPropertyName("Code Setor")]
        public int SetorId { get; set; }


        [JsonPropertyName("Setor")]
        public SetorVO SetoresVO { get; set; }


        [Required]
        [JsonPropertyName("Code Computador")]
        public int ComputadorId{ get ; set ;}

        [JsonPropertyName("Computador")]
        public ComputadorVO ComputadoresVO { get; set; }


        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }




}
