using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Marvel.WebApi.Domains
{
    public class PersonagemDomain
    {
        public int Id { get; set; }
        public string Personagem { get; set; }
        public string Lançamento { get; set; }
        public string Descrição { get; set; }
    }
}
