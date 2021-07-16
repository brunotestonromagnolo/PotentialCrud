using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PotentialCrudApplication.Dto;
using PotentialCrudApplication.Interface;
using PotentialCrudCommon.Exceptions;
using System;
using System.Linq;

namespace PotentialCrudAPI.Controllers
{
    [Route("desenvolvedor")]
    [ApiController]    
    public class DesenvolvedorController : Controller
    {
        private readonly IApplicationServiceDesenvolvedor applicationServiceDesenvolvedor;

        public DesenvolvedorController(IApplicationServiceDesenvolvedor applicationServiceDesenvolvedor)
        {
            this.applicationServiceDesenvolvedor = applicationServiceDesenvolvedor;
        }

        // GET
        [HttpGet]
        [ProducesResponseType(typeof(DesenvolvedorDto), StatusCodes.Status200OK)]
        public ActionResult Get()
        {
            return Ok(applicationServiceDesenvolvedor.GetAll());
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DesenvolvedorDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DesenvolvedorDto), StatusCodes.Status404NotFound)]
        public ActionResult Get([FromRoute] int id)
        {            
            var desenvolvedor = applicationServiceDesenvolvedor.GetListById(id).ToList();
                        
            if (!desenvolvedor.Any())
                return NotFound();

            return Ok(desenvolvedor);            
        }
        
        [HttpGet("GetByQueryString/{queryString}")]
        [ProducesResponseType(typeof(DesenvolvedorDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DesenvolvedorDto), StatusCodes.Status404NotFound)]
        public ActionResult Get(string queryString, [FromQuery] int? qtdRegistros, [FromQuery] int? pagina)
        {
            var desenvolvedores = applicationServiceDesenvolvedor.GetByQueryString(queryString, qtdRegistros, pagina);
            if (!desenvolvedores.Any())
                return NotFound();

            return Ok(desenvolvedores);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(typeof(DesenvolvedorDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]        
        public ActionResult Post([FromBody] DesenvolvedorDto desenvolvedorDto)
        {   
            try
            {                 
                if (desenvolvedorDto == null)
                    throw new ParameterInvalidException("Não foi informado os dados!");                

                var idInserido = applicationServiceDesenvolvedor.Add(desenvolvedorDto);
                return CreatedAtAction("Post", new DesenvolvedorDto { Id = idInserido });
            }
            catch(ExceptionBase ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException);
            }
        }

        // PUT 
        [HttpPut]
        [ProducesResponseType(typeof(DesenvolvedorDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DesenvolvedorDto), StatusCodes.Status400BadRequest)]
        public ActionResult Put([FromBody] DesenvolvedorDto desenvolvedorDto)
        {
            try
            {                
                if (desenvolvedorDto == null)
                    throw new ParameterInvalidException("Não foi informado os dados!");

                applicationServiceDesenvolvedor.Update(desenvolvedorDto);
                return Ok();
            }
            catch (ExceptionBase ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException);
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        [ProducesResponseType(typeof(DesenvolvedorDto), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Delete([FromHeader] int id)        
        {
            try
            {
                applicationServiceDesenvolvedor.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
