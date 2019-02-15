using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Interfaces;
using Senai.Svigufo.WebApi.Repositories;

namespace Senai.Svigufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicoesController : ControllerBase
    {
        List<InstituicaoDomain> instituicoes = new List<InstituicaoDomain>()
        {
            new InstituicaoDomain {Id = 1, NomeFantasia = "Modapel", RazaoSocial = "Imperatriz", CNPJ = "10020030040050", Logradouro = "Av. Silvio de Campos, n 191 - Perus", CEP = "05211220", UF = "SP", Cidade = "São Paulo" }
        };

        private IInstituicaoRepository InstituicaoRepository { get; set; }

        public InstituicoesController()
        {
            InstituicaoRepository = new InstituicaoRepository();
        }

        [HttpGet]
        public IEnumerable<InstituicaoDomain> Get()
        {
            return InstituicaoRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Busca um tipo de evento pelo seu id

            InstituicaoDomain instituicaoProcurada = new InstituicaoDomain(); //Só instanciar não adianta é necessario igualar o objeto ao que estamos procurando

            instituicaoProcurada = InstituicaoRepository.BuscarPorId(id);

            //InstituicaoDomain instituicaoProcurada = instituicoes.Find(x => x.Id == id); --- Está buscando pela lista fixa
            if (instituicaoProcurada == null)
            {
                return NotFound();
            }

            return Ok(instituicaoProcurada);
        }

        [HttpPost]
        public IActionResult Post (InstituicaoDomain instituicao)
        {
            InstituicaoRepository.Gravar(instituicao);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id )
        {
            InstituicaoRepository.Excluir(id);
            return Ok();
        }
    }
}
