using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Interfaces;
using Senai.Svigufo.WebApi.Repositories;
using Senai.Svigufo.WebApi.ViewModel;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Senai.Svigufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private IUsuarioRepository UsuarioRepository { get; set; }

        public LoginController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post (LoginViewModel login)
        {
            try
            {
                UsuarioDomain usuario = UsuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);

                if (usuario == null)
                {
                    return NotFound(new { mensagem = "Usuário não encontrado!!" });
                }

                var claims = new[]
                {
                    new Claim (JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim (JwtRegisteredClaimNames.Jti, usuario.Id.ToString()),
                    new Claim (ClaimTypes.Role, usuario.TipoUsuario)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("svigufo-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Svigufo.Web.Api",
                    audience: "Svigufo.Web.Api",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);
                
                return Ok(new { token = new JwtSecurityTokenHandler ().WriteToken(token)});
            }
            catch(Exception ex)
            {
                return BadRequest(new {mensagem = "Deu erro!!"});
            }
        }
    }
}