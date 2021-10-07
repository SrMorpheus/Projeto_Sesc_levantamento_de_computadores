using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Models
{
    public class Usuario
    {

        public int IdUsuario { get; set; }

        public string NomeUsuario { get; set; }

        public int SetorId { get; set; }

        public Setor Setores { get; set; }


        public int ComputadorId{ get ; set ;}
        
        public Computador Computadores { get; set; }
    }
}
