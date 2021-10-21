using Projeto_Inventáro.Data.Converter.Implementation;
using Projeto_Inventáro.Models;
using Projeto_Inventáro.Models.Context;
using Projeto_Inventáro.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Services.Implementations
{
    public class UsuarioServiceImplementation : IUsuarioService
    {

        private readonly IUsuarioRepository _usuarioRepository;

        private readonly UsuarioConverter _converter;




        public UsuarioServiceImplementation(IUsuarioRepository usuarioRepository)
        {

            _usuarioRepository = usuarioRepository;


            _converter = new UsuarioConverter();
        }

   
        public UsuarioVO Create(UsuarioVO usuario)
        {


            var usuarioEntity = _converter.Parse(usuario);

            usuarioEntity = _usuarioRepository.Create(usuarioEntity);


            return _converter.Parse(usuarioEntity);

        }

        public void Delete(int id)
        {


            _usuarioRepository.Delete(id);



        }

        public List<UsuarioVO> FindAll()

            
        {


            return _converter.Parse(_usuarioRepository.FindAll());



        }

        public UsuarioVO FindById(int id)
        {



            return _converter.Parse( _usuarioRepository.FindById(id));

        }

        public List<UsuarioVO> SetorPesquisar(int id)
        {

            return _converter.Parse(_usuarioRepository.SetorPesquisar(id));
        
        }
        public List<UsuarioVO> ComputadorPesquisar(int id)
        {

            return _converter.Parse(_usuarioRepository.ComputadorPesquisar(id));

        }


        public UsuarioVO Update(UsuarioVO usuario)
        {


            var usuarioEntity = _converter.Parse(usuario);

            usuarioEntity = _usuarioRepository.Update(usuarioEntity);


            return _converter.Parse(usuarioEntity);
        }

     
    }
}
