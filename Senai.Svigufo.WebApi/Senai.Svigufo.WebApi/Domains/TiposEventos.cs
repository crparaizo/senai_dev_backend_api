using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senai.Svigufo.WebApi.Domains
{
    [Table("TIPOS_EVENTOS")]
    public partial class TiposEventos
    {
        public TiposEventos()
        {
            Eventos = new HashSet<Eventos>();
        }

        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("TITULO")]
        [StringLength(255)]
        public string Titulo { get; set; }

        [InverseProperty("IdTipoEventoNavigation")]
        public ICollection<Eventos> Eventos { get; set; }
    }
}
