using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto_Inventáro.Data.VO;
using Projeto_Inventáro.Services;
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
    public class EquipamentoController : ControllerBase
    {

        private readonly ILogger<EquipamentoController> _logger;

        private IEquipamentoService _equipamentoService;




        public EquipamentoController(ILogger<EquipamentoController> logger, IEquipamentoService equipamentoService)
        {


            _logger = logger;

            _equipamentoService = equipamentoService;

        }


        [HttpGet] //lista os Equipamentos 
        [ProducesResponseType((200), Type = typeof(List<EquipamentoVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]


        public IActionResult Get()
        {

            var equipamento = _equipamentoService.FindAll();


            if (!equipamento.Any())
            {
                return NotFound();
            }


            return Ok(equipamento);






        }

        [HttpGet("{id}")] //lista equipamento por id
        [ProducesResponseType((200), Type = typeof(EquipamentoVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]


        public IActionResult Get(int id)
        {
            var equipamento = _equipamentoService.FindById(id);




            if (equipamento == null)
            {

                return NotFound();

            }

            return Ok(equipamento);



        }






        [HttpPost] //create 
        [ProducesResponseType((200), Type = typeof(EquipamentoVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]


        public IActionResult Post([FromBody] EquipamentoVO equipamento)
        {

            if (equipamento == null) return BadRequest();

            return Ok(_equipamentoService.Create(equipamento));

        }



        [HttpPut] //update
        [ProducesResponseType((200), Type = typeof(EquipamentoVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]



        public IActionResult Put([FromBody] EquipamentoVO equipamento)
        {

            if (equipamento == null) return BadRequest();

            return Ok(_equipamentoService.Update(equipamento));

        }




        [HttpDelete("{id}")] //Delete
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]


        public IActionResult Delete(int id)
        {

            _equipamentoService.Delete(id);

            return NoContent();

        }




    }
}
