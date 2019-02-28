using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senai.InLock.CodeFirst.WebApi.Domains
{
    [Table("Jogos")]
    public class JogoDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JogoId { get; set; }

        [Column (TypeName = "varchar (150)")]
        [Required]
        public string NomeJogo { get; set; }

        [Column(TypeName = "Text")]
        [Required]
        public string Descricao { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DataLancamento { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        public Decimal Valor { get; set; }

        [Required]
        //Gravação
        public int EstudioId { get; set; }

        [ForeignKey("EstudioId")]
        //Leitura
        public EstudioDomain Estudio { get; set; }
    }
}