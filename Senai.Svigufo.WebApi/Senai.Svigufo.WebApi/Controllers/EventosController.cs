using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Interfaces;
using Senai.Svigufo.WebApi.Repositories;
using System;

namespace Senai.Svigufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {

        private IEventoRepository EventoRepository { get; set; }

        public EventosController()
        {
            EventoRepository = new EventoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(EventoRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post(EventoDomain evento)
        {
            try
            {
                EventoRepository.Cadastrar(evento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut ("{id}")]
        public IActionResult Put (EventoDomain evento, int id)
        {
            try
            {
                EventoRepository.Atualizar(evento, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}