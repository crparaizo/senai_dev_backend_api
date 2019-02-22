using Senai.Svigufo.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.Svigufo.WebApi.Interfaces
{
    interface IConviteRepository
    {
        /// <summary>
        /// Lista com todos os arquivos
        /// </summary>
        /// <returns>A lista com todos os convites</returns>
        List<ConviteDomain> Listar();

        /// <summary>
        /// Listar somente os convites do usuário
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <returns>Lista de Convites de Usuário</returns>
        List<ConviteDomain> ListarMeusConvites(int usuarioId);

        void Cadastrar(ConviteDomain convite);
    }
}