using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senai.Svigufo.WebApi.Domains
{
    [Table("CONVITES")]
    public partial class Convites
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("ID_USUARIO")]
        public int? IdUsuario { get; set; }
        [Column("ID_EVENTO")]
        public int? IdEvento { get; set; }
        [Column("SITUACAO")]
        [StringLength(1)]
        public string Situacao { get; set; }

        [ForeignKey("IdEvento")]
        [InverseProperty("Convites")]
        public Eventos IdEventoNavigation { get; set; }
        [ForeignKey("IdUsuario")]
        [InverseProperty("Convites")]
        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
