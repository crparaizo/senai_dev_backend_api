using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Senai.InLock.DatabaseFirst.WebApi.Domains;

namespace Senai.InLock.DatabaseFirst.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get ()
        {
            try
            {
                using (InLockContext ctx = new InLockContext())
                {
                    return Ok(ctx.Estudios.ToList());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + "ERRROOO" });
            }
        }

        // GET - api/estudios/estudiosComJogos
        [HttpGet ("estudiosComJogos")]
        public IActionResult BuscarEstudiosComJogos()
        {
            try
            {
                using (InLockContext ctx = new InLockContext())
                {
                    //return Ok(ctx.Estudios.Include("Jogos").ToList());
                    return Ok(ctx.Estudios.Include(x => x.Jogos).ToList());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + "ERRROOO" });
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Estudios estudio)
        {
            try
            {
                using (InLockContext ctx = new InLockContext())
                {
                    ctx.Estudios.Add(estudio);
                    ctx.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + "ERRROOO" });
            }
        }

        [HttpPut]
        public IActionResult Atualizar(Estudios estudio)
        {
            try
            {
                using (InLockContext ctx = new InLockContext())
                {
                    Estudios estudioProcurado = ctx.Estudios.Find(estudio.EstudioId);

                    if (estudioProcurado == null)
                    {
                        return NotFound();
                    }

                    estudioProcurado.NomeEstudio = estudio.NomeEstudio;

                    ctx.Estudios.Update(estudioProcurado);

                    //ctx.Estudios.Update(estudio);
                    ctx.SaveChanges();
                }
                    return Ok();
            }
            catch (Exception ex )
            {
                return BadRequest();
            }
        }

        [HttpDelete ("{id}")]
        public IActionResult Deletar (int id)
        {
            try
            {
                using (InLockContext ctx = new InLockContext())
                {
                    Estudios estudioProcurado = ctx.Estudios.Find(id);

                    if (estudioProcurado == null)
                    {
                        return NotFound();
                    }

                    ctx.Estudios.Remove(estudioProcurado);
                    ctx.SaveChanges();

                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}