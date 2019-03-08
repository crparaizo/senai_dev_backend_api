using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senai.Svigufo.WebApi.Domains
{
    [Table("INSTITUICOES")]
    public partial class Instituicoes
    {
        public Instituicoes()
        {
            Eventos = new HashSet<Eventos>();
        }

        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("RAZAO_SOCIAL")]
        [StringLength(255)]
        public string RazaoSocial { get; set; }
        [Column("NOME_FANTASIA")]
        [StringLength(255)]
        public string NomeFantasia { get; set; }
        [Required]
        [Column("CNPJ")]
        [StringLength(14)]
        public string Cnpj { get; set; }
        [Required]
        [Column("LOGRADOURO")]
        [StringLength(255)]
        public string Logradouro { get; set; }
        [Required]
        [Column("CEP")]
        [StringLength(8)]
        public string Cep { get; set; }
        [Required]
        [Column("CIDADE")]
        [StringLength(255)]
        public string Cidade { get; set; }
        [Required]
        [Column("UF")]
        [StringLength(2)]
        public string Uf { get; set; }

        [InverseProperty("IdInstituicaoNavigation")]
        public ICollection<Eventos> Eventos { get; set; }
    }
}
