using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senai.Svigufo.WebApi.Domains
{
    [Table("EVENTOS")]
    public partial class Eventos
    {
        public Eventos()
        {
            Convites = new HashSet<Convites>();
        }

        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("TITULO")]
        [StringLength(255)]
        public string Titulo { get; set; }
        [Column("DESCRICAO", TypeName = "text")]
        public string Descricao { get; set; }
        [Column("DATA_EVENTO", TypeName = "datetime")]
        public DateTime DataEvento { get; set; }
        [Column("ACESSO_LIVRE")]
        public bool? AcessoLivre { get; set; }
        [Column("ID_TIPO_EVENTO")]
        public int? IdTipoEvento { get; set; }
        [Column("ID_INSTITUICAO")]
        public int? IdInstituicao { get; set; }

        [ForeignKey("IdInstituicao")]
        [InverseProperty("Eventos")]
        public Instituicoes IdInstituicaoNavigation { get; set; }
        [ForeignKey("IdTipoEvento")]
        [InverseProperty("Eventos")]
        public TiposEventos IdTipoEventoNavigation { get; set; }
        [InverseProperty("IdEventoNavigation")]
        public ICollection<Convites> Convites { get; set; }
    }
}
