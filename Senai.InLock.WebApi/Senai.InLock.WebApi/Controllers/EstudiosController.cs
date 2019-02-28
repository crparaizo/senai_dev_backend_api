using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {

        private IEstudioRepository EstudioRepository { get; set; }

        public EstudiosController()
        {
            EstudioRepository = new EstudioRepository();
        }

        //[Authorize (Roles = "ADMINISTRADOR")]

        //[Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(EstudioRepository.Listar());
        }
    }
}