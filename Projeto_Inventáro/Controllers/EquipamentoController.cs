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
        public IActionResult Get()
        {

            var equipamento = _equipamentoService.FindAll();


            if (!equipamento.Any())
            {
                return NotFound();
            }


            return Ok(equipamento);






        }

        [HttpGet("{id}")] //lista equipamentos por id

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


        public IActionResult Post([FromBody] EquipamentoVO equipamento)
        {

            if (equipamento == null) return BadRequest();

            return Ok(_equipamentoService.Create(equipamento));

        }



        [HttpPut] //update

        public IActionResult Put([FromBody] EquipamentoVO equipamento)
        {

            if (equipamento == null) return BadRequest();

            return Ok(_equipamentoService.Update(equipamento));

        }




        [HttpDelete("{id}")] //Delete


        public IActionResult Delete(int id)
        {

            _equipamentoService.Delete(id);

            return NoContent();

        }




    }
}
