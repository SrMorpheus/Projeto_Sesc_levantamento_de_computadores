using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto_Inventáro.Data.VO;
using Projeto_Inventáro.Hypermedia.Filters;
using Projeto_Inventáro.Models;
using Projeto_Inventáro.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Controllers
{

    [ApiVersion("1")]
    [Authorize("Bearer")]
    [Route("api/v{version:apiVersion}/[controller]/")]

    [ApiController]
    public class ComputadorController : ControllerBase
    {
        private readonly ILogger<ComputadorController> _logger;

        private IComputadorService _computadorService;


        public ComputadorController(ILogger<ComputadorController> logger , IComputadorService computadorService  )
        {
            _logger = logger;

            _computadorService = computadorService;

        }


        [HttpGet] //listar todos computadores
        [ProducesResponseType( (200), Type = typeof(List<ComputadorVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        [TypeFilter(typeof(HypeMediaFilter))]
        public IActionResult Get()
        {

            var computador = _computadorService.FindAll();


                 if (!computador.Any())
            {
                return NotFound();
            }

            return Ok(computador);



        }


        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(ComputadorVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HypeMediaFilter))]

        public IActionResult Get( int id)
        {

            var computador =_computadorService.FindById(id);


            if (computador == null)
            {
                return NotFound();
            }


            return Ok(computador);

        }


        //Pesquisar pelo modelo


        [HttpGet("Modelo/{id}")]
        [ProducesResponseType((200), Type = typeof(List<ComputadorVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HypeMediaFilter))]


        public IActionResult GetModelo(int id)
        {

            var computador = _computadorService.ModeloPesquisar(id);


            if (!computador.Any())
            {
                return NotFound();
            }


            return Ok(computador);

        }

        //Pesquisar pelo Setor

        [HttpGet("Setor/{id}")]
        [ProducesResponseType((200), Type = typeof(List<ComputadorVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        [TypeFilter(typeof(HypeMediaFilter))]


        public IActionResult GetSetor(int id)
        {

            var computador = _computadorService.SetorPesquisar(id);

           
            if (!computador.Any())
            {
                return NotFound();
            }


            return Ok(computador);

        }

        //Pesquisar pelo equipamento

        [HttpGet("Equipamento/{id}")]

        [ProducesResponseType((200), Type = typeof(List<ComputadorVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        [TypeFilter(typeof(HypeMediaFilter))]


        public IActionResult GetEquipamento(int id)
        {

            var computador = _computadorService.EquipamentoPesquisar(id);


            if (!computador.Any())
            {
                return NotFound();
            }


            return Ok(computador);

        }





        [HttpPost] //CREATE
        [ProducesResponseType((200), Type = typeof(ComputadorVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HypeMediaFilter))]


        public IActionResult Post([FromBody] ComputadorVO computador)
        {
            if (computador == null) return BadRequest();

            return Ok(_computadorService.Create(computador));

        }


        [HttpPut] //UPDATE
        [ProducesResponseType((200), Type = typeof(ComputadorVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HypeMediaFilter))]

        public IActionResult Put([FromBody] ComputadorVO computador)
        {
            if (computador == null) return BadRequest();

            return Ok(_computadorService.Update(computador));

        }



        [HttpDelete("{id}")] //Delete
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        public IActionResult Delete(int id)
        {
            
            _computadorService.Delete(id);

       
            return NoContent();

        }



    }
}
