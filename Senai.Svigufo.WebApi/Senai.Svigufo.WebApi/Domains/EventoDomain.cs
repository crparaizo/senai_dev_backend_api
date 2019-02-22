using System;

namespace Senai.Svigufo.WebApi.Domains
{
    public class EventoDomain
    {
        /// <summary>
        /// Classe que representa os dados da Tabela Eventos
        /// </summary>
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime DataEvento { get; set; }

        public bool AcessoLivre { get; set; }

        public int TipoEventoId { get; set; }
        public TipoEventoDomain TipoEvento { get; set; }

        public int InstituicaoId { get; set; }
        public InstituicaoDomain Instituicao { get; set; }
    }
}