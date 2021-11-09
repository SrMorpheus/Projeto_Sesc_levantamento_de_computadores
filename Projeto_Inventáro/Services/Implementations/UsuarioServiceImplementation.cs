using Projeto_Inventáro.Data.Converter.Implementation;
using Projeto_Inventáro.Hypermedia.Utils;
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

        public List<UsuarioVO> FindByName(string nome)
        {

            return _converter.Parse(_usuarioRepository.FindByName(nome));

        }

        public PagedSearchVO<UsuarioVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {


            var sort = (!string.IsNullOrWhiteSpace(sortDirection) && !sortDirection.Equals("desc")) ? "asc" : "desc";

            var size = (pageSize < 1) ? 10 : pageSize;

            var offset = page > 0 ? (page - 1) * size : 0;


            string query = @"select *from tbl_usuario  U where 1 = 1";

            if (!string.IsNullOrWhiteSpace(name)) query = query + $" and U.nome_usuario Like '%{name}%' ";


            query += $"  order by U.nome_usuario {sort} limit {size} offset {offset}";



            string countQuery = @"select count(*) from tbl_usuario as U where 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(name)) countQuery = countQuery + $"and U.nome_usuario Like '%{name}%' ";

            var usuarios = _usuarioRepository.FindWithPagedSearch(query);

            int totalResult = _usuarioRepository.GetCount(countQuery);

            return new PagedSearchVO<UsuarioVO>
            {

                CurrentPage = page,

                List = _converter.Parse(usuarios),

                PageSize = size,

                SortDirections = sort,

                TotalResult = totalResult



            };




        }

    }
}
