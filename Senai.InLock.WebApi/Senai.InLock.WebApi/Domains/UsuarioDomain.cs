﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class UsuarioDomain
    {
        public int UsuarioId { get; set; }

        public string Email { get; set; }
        
        public string Senha { get; set; }

        public string TipoUsuario { get; set; }
    }
}