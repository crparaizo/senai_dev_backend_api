using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.WebApi.Interfaces;
using Senai.Svigufo.WebApi.Repositories;

namespace Senai.Svigufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConvitesController : ControllerBase
    {
        private IConviteRepository ConviteRepository {get; set;}

        public ConvitesController()
        {
            ConviteRepository = new ConviteRepository();
        }

        /// <summary>
        /// Somente os administradores terão acesso a todos os convites
        /// </summary>
        [Authorize (Roles = "Administrador")]

        //é a mesma regra que será autorizada a realizar as atividades
    
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                ConviteRepository.Listar();
                
                return Ok(ConviteRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(new {mensagem = "Erro "});
            }
        }

        [Authorize]
        [HttpGet]
        //Posso definir um rota para ele
        [Route("meus")]
        // /api/convites/meus
        public IActionResult MeusConvites ()
        {
            try
            {
                int usuarioId = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                return Ok(ConviteRepository.ListarMeusConvites(usuarioId));
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "ERRO" });
            }
        }

        [Authorize]
        [HttpPost ("{eventoId")]
        // /api/convite/inscricao/{eventoId}
        [Route("inscricao/{eventoId}")]
        public IActionResult Inscricao (int eventoId)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro " });             
            }
        }
    }
}