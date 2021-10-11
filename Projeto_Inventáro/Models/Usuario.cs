using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Models
{

    [Table("tbl_usuario")]
    public class Usuario
    {

        [Key]
        [Column("cod_usuario")]
        public int IdUsuario { get; set; }

        [Column("nome_usuario")]
        public string NomeUsuario { get; set; }

        [Column("fk_setor")]
        public int SetorId { get; set; }

        public Setor Setores { get; set; }

        [Column("fk_computador")]
        public int ComputadorId{ get ; set ;}
        
        public Computador Computadores { get; set; }
    }
}
