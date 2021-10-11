using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Models
{

    [Table("tbl_setor")]
    public class Setor
    {
        [Key]
        [Column("cod_setor")]
        public int IdSetor { get; set; }

        [Column("nome_setor")]
        public string NomeSetor { get; set; }
        

    }
}
