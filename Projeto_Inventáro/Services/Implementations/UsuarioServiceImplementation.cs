using Projeto_Inventáro.Models;
using Projeto_Inventáro.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Services.Implementations
{
    public class UsuarioServiceImplementation : IUsuarioServicecs
    {

        private MySQLContext _context;


        public UsuarioServiceImplementation(MySQLContext context)
        {
            _context = context;

        }


        public Usuario Create(Usuario usuario)
        {

            try
            {
                _context.Add(usuario);

                _context.SaveChanges();

            }
            catch ( Exception ex)
            {
                throw ex;
            }

            return usuario;

        }

        public void Delete(int id)
        {


            var result = _context.Usuarios.SingleOrDefault(U => U.IdUsuario.Equals(id));


            if (result != null)
            {

                try
                {
                    _context.Usuarios.Remove(result);

                    _context.SaveChanges();


                }catch (Exception)
                {
                    throw;

                }

            }



        }

        public List<Usuario> FindAll()

            
        {
           
           
            return _context.Usuarios.ToList();

            
        }

        public Usuario FindById(int id)
        {



            return _context.Usuarios.SingleOrDefault(U => U.IdUsuario.Equals(id));


        }

        public Usuario Update(Usuario usuario)
        {

            if (!Exists(usuario.IdUsuario)) return new Usuario();

            var result = _context.Usuarios.SingleOrDefault(U => U.IdUsuario.Equals(usuario.IdUsuario));


            if (result != null)
            {
                try
                {

                    _context.Entry(result).CurrentValues.SetValues(usuario);

                    _context.SaveChanges();


                }
                catch (Exception ex)
                {
                    throw ex;

                }


            }

            return usuario;
        }

        private bool Exists(int id)
        {


            return _context.Usuarios.Any(U => U.IdUsuario.Equals(id));
        }
    }
}
