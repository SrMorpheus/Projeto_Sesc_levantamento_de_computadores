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


        public UsuarioServiceImplementation(IUsuarioRepository usuarioRepository)
        {

            _usuarioRepository = usuarioRepository;

        }


        public Usuario Create(Usuario usuario)
        {

            
           return _usuarioRepository.Create(usuario);
        }

        public void Delete(int id)
        {


            _usuarioRepository.Delete(id);



        }

        public List<Usuario> FindAll()

            
        {


            return _usuarioRepository.FindAll();



        }

        public Usuario FindById(int id)
        {



            return _usuarioRepository.FindById(id);

        }

        public Usuario Update(Usuario usuario)
        {

            return _usuarioRepository.Update(usuario);
        }

     
    }
}
