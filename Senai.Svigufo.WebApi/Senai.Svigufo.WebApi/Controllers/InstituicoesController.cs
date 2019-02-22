using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
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
        }; //Lista local

        private IInstituicaoRepository InstituicaoRepository { get; set; }

        public InstituicoesController()
        {
            InstituicaoRepository = new InstituicaoRepository();
        }

        /*
        [HttpGet]
        public IEnumerable<InstituicaoDomain> Get()
        {
            return InstituicaoRepository.Listar();
        }
        */

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok (InstituicaoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Busca um tipo de evento pelo seu id

            InstituicaoDomain instituicaoProcurada = new InstituicaoDomain(); //Só instanciar não adianta é necessario igualar o objeto ao que estamos procurando

            //InstituicaoDomain instituicaoProcurada = InstituicaoRepository.BuscarPorId(id);

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
            try
            {
                InstituicaoRepository.Gravar(instituicao);
                return Ok();
            } catch {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try {
                InstituicaoRepository.Excluir(id);
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, InstituicaoDomain instituicao)
        {
            InstituicaoDomain instituicaoProcurada = InstituicaoRepository.BuscarPorId(id);

            if (instituicaoProcurada == null)
            {
                return NotFound(
                    new
                    {
                        mensagem = "A instiuição não foi encontrada",
                        erro = true
                    }
                    );
            }

            try
            {
                InstituicaoRepository.Editar(id, instituicao);
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }
    }
}