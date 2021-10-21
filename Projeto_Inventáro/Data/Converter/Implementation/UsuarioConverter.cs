using Projeto_Inventáro.Data.Converter.Contract;
using Projeto_Inventáro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Data.Converter.Implementation
{
    public class UsuarioConverter : IUsuario<UsuarioVO, Usuario>, IUsuario<Usuario, UsuarioVO>
    {


        private readonly SetorConverter _setorConverter;

        private readonly ComputadorConverter _computadorConverter;


        public UsuarioConverter()
        {

            _setorConverter = new SetorConverter();

            _computadorConverter = new ComputadorConverter();

        }

        public UsuarioVO Parse(Usuario origin)
        {



            if (origin == null) return null;
            
           return new UsuarioVO

           {
               IdUsuario = origin.IdUsuario,

               NomeUsuario = origin.NomeUsuario,

               SetoresVO = _setorConverter.Parse( origin.Setores),

               SetorId = origin.SetorId,

               ComputadoresVO = _computadorConverter.Parse( origin.Computadores),

               ComputadorId = origin.ComputadorId

           };


        }



        public Usuario Parse(UsuarioVO origin)
        {

            if (origin == null) return null;
            
           return new Usuario

           {
               IdUsuario = origin.IdUsuario,

               NomeUsuario = origin.NomeUsuario,

               Setores = _setorConverter.Parse( origin.SetoresVO),

               SetorId = origin.SetorId,

               Computadores = _computadorConverter.Parse( origin.ComputadoresVO),


               ComputadorId = origin.ComputadorId

           };


        }

        public List<Usuario> Parse(List<UsuarioVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public List<UsuarioVO> Parse(List<Usuario> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();

        }
    }
}
