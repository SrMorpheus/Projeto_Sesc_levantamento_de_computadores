using Projeto_Inventáro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Data.VO
{



    public class ComputadorVO
    {


   
        public int IdComputador { get; set; }


      
        public string NomeComputador { get; set; }

        //  [Required()]

    
        public Modelo Modelos { get; set; }

    
        public int ModeloId { get; set; }

        //[Required()]
        public Equipamento Equipamentos { get; set; }

   
        public int EquipamentoId { get; set; }

        [Required()]

        public string EnderecoIp { get; set; }

        public int PatrimonioMonitor { get; set; }

        [Required()]
       
        public int PatrimonioGabinete { get; set; }

        [Required()]
       
        public int Ano { get; set; }

      
        public bool Internet  {get; set ;}




        public int SetorId { get; set; }

       // [Required()]
        public Setor Setores { get; set; }






    }
}
