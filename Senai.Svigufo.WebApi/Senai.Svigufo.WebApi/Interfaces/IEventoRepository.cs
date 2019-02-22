using Senai.Svigufo.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.Svigufo.WebApi.Interfaces
{
    interface IEventoRepository
    {
        List<EventoDomain> Listar();

        void Cadastrar(EventoDomain evento);

        void Atualizar(EventoDomain evento, int id);
    }
}