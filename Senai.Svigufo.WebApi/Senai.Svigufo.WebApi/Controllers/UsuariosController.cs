using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Interfaces;
using Senai.Svigufo.WebApi.Repositories;

namespace Senai.Svigufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController] // Tira a necessidade de colocar o FromBody
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public UsuariosController()
        {
            UsuarioRepository = new UsuarioRepository();
        }
        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="usuario">UsuarioDomain</param>
        /// <returns>Retorna um status code</returns>
        [HttpPost]
        public IActionResult Post(UsuarioDomain usuario) //IActionResult é para saber o status da requisição: ex. NotFound, Ok,...
        {
            try
            {
                UsuarioRepository.Cadastrar(usuario);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}