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
    public class ModeloController : ControllerBase
    {

          private readonly ILogger<ModeloController> _logger;

          private IModeloService _modeloService;




        public ModeloController(ILogger<ModeloController> logger, IModeloService modeloService)
        {


            _logger = logger;

            _modeloService = modeloService;

        }


        [HttpGet] //lista os usuarios com sesu computadores 
        public IActionResult Get()
        {

            var modelo = _modeloService.FindAll();


            if (!modelo.Any())
            {
                return NotFound();
            }


            return Ok(modelo);

        

            


        }

        [HttpGet("{id}")] //lista o usuario pelo id 

        public IActionResult Get(int id)
        {
            var modelo = _modeloService.FindById(id);

         
            

            if (modelo == null)
            {

                return NotFound();

            }

            return Ok(modelo);



        }


 



        [HttpPost] //create 


        public IActionResult Post([FromBody] ModeloVO modelo)
        {

            if (modelo == null) return BadRequest();

            return Ok(_modeloService.Create(modelo));

        }



        [HttpPut] //update

        public IActionResult Put([FromBody] ModeloVO modelo)
        {

            if (modelo == null) return BadRequest();

            return Ok(_modeloService.Update(modelo));

        }




        [HttpDelete("{id}")] //Delete


        public IActionResult Delete(int id)
        {

            _modeloService.Delete(id);

            return NoContent();

        }



    }
}
