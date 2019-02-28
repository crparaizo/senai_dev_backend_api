using Senai.InLock.WebApi.Domains;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        UsuarioDomain BuscarEmailSenha(string email, string senha);
    }
}