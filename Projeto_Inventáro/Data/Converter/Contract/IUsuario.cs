using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Data.Converter.Contract
{
   public  interface IUsuario<O, D>
    {


    
        D Parse(O origin);

        List<D> Parse(List<O> origin);





    }
}
