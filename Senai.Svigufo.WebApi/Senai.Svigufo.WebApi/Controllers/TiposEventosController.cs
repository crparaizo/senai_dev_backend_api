using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.Svigufo.WebApi.Controllers
{
    //Define que o retorno será um json
    [Produces("application/json")]

    [Route("api/[controller]")]
    public class TiposEventosController : ControllerBase
    {
        //Declaração de um objeto list do tipo TipoEventoDomain
        List<TipoEventoDomain> tiposEventos = new List<TipoEventoDomain>()
        {
            new TipoEventoDomain { Id = 1, Nome = "Tecnologia"},
            new TipoEventoDomain { Id = 2, Nome = "Arquitetura"},
            new TipoEventoDomain { Id = 3, Nome = "Engenharia"},
            new TipoEventoDomain { Id = 4, Nome = "Medicina"}
        };

        /// <summary>
        /// Retorna uma string através do método Get
        /// </summary>
        /// <returns>String</returns>
        //[HttpGet]
        //public string Get ()
        //{
        //    return "Requisição recebida com sucesso";
        //}

        [HttpGet]
        //Retorna uma lista de eventos
        public IEnumerable<TipoEventoDomain> Get()
        {
            return tiposEventos;
        }

        /// <summary>
        /// Retorna um tipo de evento pelo seu Id
        /// </summary>
        /// <param name="id">id do evento</param>
        /// <returns>TipoEventoDomain</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Busca um tipo de evento pelo seu id
            TipoEventoDomain tipoEventoSerProcurado = tiposEventos.Find(x => x.Id == id);

            if (tipoEventoSerProcurado == null)
            {
                return NotFound();
            }

            return Ok(tipoEventoSerProcurado);
        }
    }
}