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
    [ApiVersion ("1")]
    [Route("api/v{version:apiVersion}/[controller]/")]

    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly ILogger<UsuarioController> _logger;

        private IUsuarioService _usuarioServicecs;




        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioService usuarioServicecs)
        {


            _logger = logger;

            _usuarioServicecs = usuarioServicecs;

        }


        [HttpGet] //lista os usuarios com sesu computadores 
        public IActionResult Get()
        {

            var usuario = _usuarioServicecs.FindAll();


            if (!usuario.Any())
            {
                return NotFound();
            }


            return Ok(usuario);

        

            


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


        //Pesquisar pelo Setor

        [HttpGet("Setor/{id}")]

        public IActionResult GetSetor(int id)
        {

            var usuario = _usuarioServicecs.SetorPesquisar(id);


            if (!usuario.Any())
            {
                return NotFound();
            }


            return Ok(usuario);

        }



        //Pesquisar pelo computadores usados

        [HttpGet("Computador/{id}")]

        public IActionResult GetComputador(int id)
        {

            var usuario = _usuarioServicecs.ComputadorPesquisar(id);


            if (!usuario.Any())
            {
                return NotFound();
            }


            return Ok(usuario);

        }






        [HttpPost] //create 


        public IActionResult Post([FromBody] UsuarioVO usuario)
        {

            if (usuario == null) return BadRequest();

            return Ok(_usuarioServicecs.Create(usuario));

        }



        [HttpPut] //update

        public IActionResult Put([FromBody] UsuarioVO usuario)
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
