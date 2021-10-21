using Microsoft.EntityFrameworkCore;
using Projeto_Inventáro.Models;
using Projeto_Inventáro.Models.Context;
using Projeto_Inventáro.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Repository
{
    public class UsuarioRepositoryImplementation : IUsuarioRepository
    {

        private MySQLContext _context;


        public UsuarioRepositoryImplementation(MySQLContext context)
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
            var usuario = _context.Usuarios.Include(C => C.Computadores).Include(S => S.Setores).Include(E => E.Computadores.Equipamentos).Include(S => S.Computadores.Setores).Include(M => M.Computadores.Modelos);
           
           
            return usuario.ToList();

            
        }

        public Usuario FindById(int id)
        {

            var usuario = _context.Usuarios.Include(C => C.Computadores).Include(S => S.Setores).Include(E => E.Computadores.Equipamentos).Include(S => S.Computadores.Setores).Include(M => M.Computadores.Modelos).SingleOrDefault(U => U.IdUsuario.Equals(id));


            return usuario;


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

        public bool Exists(int id)
        {


            return _context.Usuarios.Any(U => U.IdUsuario.Equals(id));
        }

        public List<Usuario> SetorPesquisar(int id)
        {

            var usuario = _context.Usuarios.Include(C => C.Computadores).Include(S => S.Setores).Include(E => E.Computadores.Equipamentos).Include(S => S.Computadores.Setores).Include(M => M.Computadores.Modelos).AsNoTracking().Where( S => S.SetorId == id);

            return usuario.ToList();

        }

        public List<Usuario> ComputadorPesquisar(int id)
        {
            var usuario = _context.Usuarios.Include(C => C.Computadores).Include(S => S.Setores).Include(E => E.Computadores.Equipamentos).Include(S => S.Computadores.Setores).Include(M => M.Computadores.Modelos).AsNoTracking().Where(C => C.ComputadorId == id);

            return usuario.ToList();
        }
    }
}
