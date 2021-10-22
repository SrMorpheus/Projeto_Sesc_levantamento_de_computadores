using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Models
{



    [Table ("tbl_computador")]
    public class Computador
    {


        [Key]
        [Column("cod_computador")]
        public int IdComputador { get; set; }


       
        [Column("nome_computador")]
        public string NomeComputador { get; set; }

  

    
        public Modelo Modelos { get; set; }

        [Column("fk_modelo")]
        public int ModeloId { get; set; }

        public Equipamento Equipamentos { get; set; }

        [Column("fk_tipo")]
        public int EquipamentoId { get; set; }

     

        [Column("endereco_ip")]
        public string EnderecoIp { get; set; }

        [Column("patrimonio_Monitor")]
        public int PatrimonioMonitor { get; set; }

        
        [Column("patrimonio_Gabinete")]
        public int PatrimonioGabinete { get; set; }

        [Column("ano_aquisicao")]
        public int Ano { get; set; }

        [Column("Internet_Liberada")]
        public bool Internet  {get; set ;}



        [Column("fk_setor")]
        public int SetorId { get; set; }

        public Setor Setores { get; set; }


        public IList<Usuario> Usuarios { get; } = new List<Usuario>();






    }
}
