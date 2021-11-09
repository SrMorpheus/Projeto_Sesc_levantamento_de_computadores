using Projeto_Inventáro.Data.Converter.Implementation;
using Projeto_Inventáro.Data.VO;
using Projeto_Inventáro.Hypermedia.Utils;
using Projeto_Inventáro.Models;
using Projeto_Inventáro.Models.Context;
using Projeto_Inventáro.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Services.Implementations
{
    public class ComputadorServiceImplementation : IComputadorService
    {




        private readonly IComputadorRepository _computadorRepository;


        private readonly ComputadorConverter _converter;



        public ComputadorServiceImplementation(IComputadorRepository computadorRepository)
        {

            _computadorRepository = computadorRepository;

            _converter = new ComputadorConverter();

        }
        public ComputadorVO Create(ComputadorVO computador)
        {


            var computadorEntity = _converter.Parse(computador);

            computadorEntity = _computadorRepository.Create(computadorEntity);

            return _converter.Parse(computadorEntity);


        }
        public ComputadorVO Update(ComputadorVO computador)
        {

            var computadorEntity = _converter.Parse(computador);

            computadorEntity = _computadorRepository.Update(computadorEntity);

            return _converter.Parse(computadorEntity);



        }

        public void Delete(int id)
        {


            _computadorRepository.Delete(id);

        }

      

        public List<ComputadorVO> FindAll()
        {

            return _converter.Parse(_computadorRepository.FindAll());

        }

       



        public ComputadorVO FindById(int id)
        {


            return _converter.Parse (_computadorRepository.FindById(id));

        }

        public List<ComputadorVO> ModeloPesquisar(int id)


        {
            return _converter.Parse(_computadorRepository.ModeloPesquisar(id));


        }

        public List<ComputadorVO> SetorPesquisar(int id)
        {

            return _converter.Parse(_computadorRepository.SetorPesquisar(id));
        }

        public List<ComputadorVO> EquipamentoPesquisar(int id)
        {
            return _converter.Parse(_computadorRepository.EquipamentoPesquisar(id));

        }

        public List<ComputadorVO> FindByName(string nomeComputador)
        {

            return _converter.Parse(_computadorRepository.FindByName(nomeComputador));

        }

        public List<ComputadorVO> FindByIp(string ip)
        {

            return _converter.Parse(_computadorRepository.FindByIp(ip));

        }

        public PagedSearchVO<ComputadorVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {


            var sort = (!string.IsNullOrWhiteSpace(sortDirection) && !sortDirection.Equals("desc"))? "asc": "desc";

            var size = (pageSize < 1) ? 10 : pageSize;

            var offset = page > 0 ? (page - 1) * size : 0;


            string query = @"select *from tbl_computador as C where 1 = 1" ;

            if (!string.IsNullOrWhiteSpace(name)) query = query + $" and C.nome_computador like '%{name}%'";


            query +=  $" order by C.nome_computador {sort} limit {size} offset {offset}";


            
            string countQuery =  @"select count(*) from tbl_computador as C where 1 = 1 ";
            
            if (!string.IsNullOrWhiteSpace(name)) countQuery = countQuery + $"and C.nome_computador Like '%{name}%' ";

            var computadores = _computadorRepository.FindWithPagedSearch(query);

            int totalResult = _computadorRepository.GetCount(countQuery);

            return new PagedSearchVO<ComputadorVO>
            {

                CurrentPage = page,

                List = _converter.Parse(computadores),

                PageSize = size,

                SortDirections = sort,

                TotalResult = totalResult



            };




        }
    }
}
