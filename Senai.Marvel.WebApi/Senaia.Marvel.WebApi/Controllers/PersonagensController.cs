using Microsoft.AspNetCore.Mvc;
using Senai.Marvel.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.Marvel.WebApi.Controllers
{
    [Produces ("application/json")]

    [Route("api/[controller]")]
    public class PersonagensController : ControllerBase
    {
        List<PersonagemDomain> personagens = new List<PersonagemDomain>()
        {
            new PersonagemDomain { Id = 1, Personagem = "Homem-Aranha", Lançamento = "Amazing Fantasy #15 (1962)", Descrição = "O adolescente que é mordido por uma aranha radioativa conseguiu se tornar no super-herói mais famoso de todos os tempos, estabelecendo uma forte conexão com todos os jovens que entram em contato com sua história." },
            new PersonagemDomain { Id = 2, Personagem = "O Incrível Hulk", Lançamento = "O Incrível Hulk #1 (1962)", Descrição = "O Incrível Hulk não é mais do que uma alegoria sobre a perda do auto-controle e como a raiva pode ser canalizada para algo positivo." },
            new PersonagemDomain { Id = 3, Personagem = "Homem de Ferro", Lançamento = "Tales of Suspense #39 (1963)", Descrição = "Homem de Ferro é um personagem conhecido por ter pegado em uma situação extremamente má e se tornar em um super-herói. Com a ajuda de dinheiro e genialidade, claro." }
        };

        [HttpGet]
        public IEnumerable<PersonagemDomain> Get()
        {
            return personagens;
        }

        [HttpGet ("{id}")]
        public IActionResult GetById (int id)
        {
            PersonagemDomain personagemProcurado = personagens.Find(x => x.Id == id);

            if (personagemProcurado == null)
            {
                return NotFound();
            }

            return Ok(personagemProcurado);
        }
   
    }
}