using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senai.Svigufo.WebApi.Domains
{
    [Table("USUARIOS")]
    public partial class Usuarios
    {
        public Usuarios()
        {
            Convites = new HashSet<Convites>();
        }

        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("NOME")]
        [StringLength(255)]
        public string Nome { get; set; }
        [Required]
        [Column("EMAIL")]
        [StringLength(250)]
        public string Email { get; set; }
        [Required]
        [Column("SENHA")]
        [StringLength(100)]
        public string Senha { get; set; }
        [Required]
        [Column("TIPO_USUARIO")]
        [StringLength(100)]
        public string TipoUsuario { get; set; }

        [InverseProperty("IdUsuarioNavigation")]
        public ICollection<Convites> Convites { get; set; }
    }
}
