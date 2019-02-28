using Microsoft.AspNetCore.Mvc;
using Senai.InLock.DatabaseFirst.WebApi.Domains;
using Senai.InLock.DatabaseFirst.WebApi.Interfaces;
using Senai.InLock.DatabaseFirst.WebApi.Repositories;
using System;

namespace Senai.InLock.DatabaseFirst.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogoRepository JogoRepository { get; set; }

        public JogosController()
        {
            JogoRepository = new JogoRepository();
        }

        [HttpGet]
        public IActionResult Get ()
        {
            try
            {                
                return Ok(JogoRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + "ERRROOO" });
            }
        }

        [HttpPost]
        public IActionResult Post(Jogos jogo)
        {
            try
            {
                JogoRepository.Adicionar(jogo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + "ERRROOO" });
            }
        }

        [HttpPut]
        public IActionResult Put (Jogos jogo)
        {
            try
            { 
                JogoRepository.Atualizar(jogo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}  