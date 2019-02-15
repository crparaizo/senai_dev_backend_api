using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Interfaces;
using Senai.Svigufo.WebApi.Repositories;
using System.Collections.Generic;

namespace Senai.Svigufo.WebApi.Controllers
{
    //Define que o retorno será um json
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController] // Implementa funcionalidades no controller
    public class TiposEventosController : ControllerBase
    {
        //Declaração de um objeto list do tipo TipoEventoDomain
        List<TipoEventoDomain> tiposEventos = new List<TipoEventoDomain>()
        {
            new TipoEventoDomain { Id = 1, Nome = "Tecnologia"},
            new TipoEventoDomain { Id = 2, Nome = "Redes"},
            new TipoEventoDomain { Id = 3, Nome = "Desenvolvimento"},
            new TipoEventoDomain { Id = 4, Nome = "Design"}
        };

        private ITipoEventoRepository TipoEventoRepository { get; set; }

        public TiposEventosController()
        {
            TipoEventoRepository = new TipoEventoRepository();
        }

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
            return TipoEventoRepository.Listar();
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

        /// <summary>
        /// Cadastra um novo tipo de evento
        /// </summary>
        /// <param name="tipoEvento">TipoEventoDomain</param>
        /// <returns>Retorna um Status Code</returns>
        [HttpPost]
        public IActionResult Post(TipoEventoDomain tipoEvento)
        {
            return Ok();
        }

        /// <summary>
        /// Atualiza um tipo de evento
        /// </summary>
        /// <param name="tipoEvento">Tipo Evento a ser atualizado</param>
        /// <returns>Retorna um status code</returns>
        [HttpPut]
        public IActionResult Put (TipoEventoDomain tipoEvento)
        {
            TipoEventoRepository.Alterar(tipoEvento);

            return Ok();
        }

        /// <summary>
        /// Altera um tipo de evento passando o id
        /// </summary>
        /// <param name="id">Id do tipo de evento</param>
        /// <param name="tipoEvento">TipoEventoDomain</param>
        /// <returns>Retorna um status code</returns>
        [HttpPut("{id}")]
        public IActionResult PutById (int id, TipoEventoDomain tipoEvento)
        {
            return Ok();
        }

        /// <summary>
        /// Deleta um registro
        /// </summary>
        /// <param name="id">Id do tipo de evento</param>
        /// <returns>Retorna status code</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {

            TipoEventoRepository.Deletar(id);

            return Ok();
        }
    }
}