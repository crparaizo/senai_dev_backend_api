using Senai.Svigufo.WebApi.Domains.Enums;

namespace Senai.Svigufo.WebApi.Domains
{
    public class ConviteDomain
    {
        public int Id { get; set; }

        public int EventoId { get; set; }
        public EventoDomain Evento { get; set; }

        public int UsuarioId { get; set; }
        public UsuarioDomain Usuario { get; set; }

        //O número da situação, informa a sua descrição - 'texto'
        public EnSituacaoConvite Situacao { get; set; }
    }
}