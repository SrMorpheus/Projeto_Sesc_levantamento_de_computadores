using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Models
{
    [Table("tbl_modelo")]
    public class Modelo
    {
        [Key]
        [Column("cod_modelo")]
        public int IdModelo { get; set; }


        [Column("nome_modelo")]
        public string NomeModelo { get; set; }





    }
}


