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

    public class SetorController : ControllerBase
    {


        private readonly ILogger<SetorController> _logger;

        private ISetorService _setorService;




        public SetorController(ILogger<SetorController> logger, ISetorService setorService)
        {


            _logger = logger;

            _setorService = setorService;

        }


        [HttpGet] //lista os setores 
        public IActionResult Get()
        {

            var setor = _setorService.FindAll();


            if (!setor.Any())
            {
                return NotFound();
            }


            return Ok(setor);






        }

        [HttpGet("{id}")] //lista setor por id

        public IActionResult Get(int id)
        {
            var setor = _setorService.FindById(id);




            if (setor == null)
            {

                return NotFound();

            }

            return Ok(setor);



        }






        [HttpPost] //create 


        public IActionResult Post([FromBody] SetorVO setor)
        {

            if (setor == null) return BadRequest();

            return Ok(_setorService.Create(setor));

        }



        [HttpPut] //update

        public IActionResult Put([FromBody] SetorVO setor)
        {

            if (setor == null) return BadRequest();

            return Ok(_setorService.Update(setor));

        }




        [HttpDelete("{id}")] //Delete


        public IActionResult Delete(int id)
        {

            _setorService.Delete(id);

            return NoContent();

        }


    }
}
