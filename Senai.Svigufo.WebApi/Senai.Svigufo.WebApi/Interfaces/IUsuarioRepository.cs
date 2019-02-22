using Senai.Svigufo.WebApi.Domains;

namespace Senai.Svigufo.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório usuário
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="usuario">UsuarioDomain</param>
        void Cadastrar(UsuarioDomain usuario);

        UsuarioDomain BuscarPorEmailSenha(string email, string senha);
    }
}