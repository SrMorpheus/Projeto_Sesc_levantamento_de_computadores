using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto_Inventáro.Models;
using Projeto_Inventáro.Services;
using Projeto_Inventáro.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly ILogger<UsuarioController> _logger;

        private IUsuarioServicecs _usuarioServicecs;




        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioServicecs usuarioServicecs)
        {


            _logger = logger;

            _usuarioServicecs = usuarioServicecs;

        }


        [HttpGet] //lista os usuarios com sesu computadores 
        public IActionResult Get()
        {

  

            return Ok(_usuarioServicecs.FindAll());

            


        }

        [HttpGet("{id}")] //lista o usuario pelo id 

        public IActionResult Get(int id)
        {
            var usuario = _usuarioServicecs.FindById(id);

         
            

            if (usuario == null)
            {

                return NotFound();

            }

            return Ok(usuario);



        }


        [HttpPost] //create 


        public IActionResult Post([FromBody] Usuario usuario)
        {

            if (usuario == null) return BadRequest();

            return Ok(_usuarioServicecs.Create(usuario));

        }



        [HttpPut] //update

        public IActionResult Put([FromBody] Usuario usuario)
        {

            if (usuario == null) return BadRequest();

            return Ok(_usuarioServicecs.Update(usuario));

        }




        [HttpDelete("{id}")] //Delete


        public IActionResult Delete(int id)
        {

            _usuarioServicecs.Delete(id);

            return NoContent();

        }




    }
}
