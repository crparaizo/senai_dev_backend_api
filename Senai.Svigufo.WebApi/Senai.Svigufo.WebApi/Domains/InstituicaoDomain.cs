using System.ComponentModel.DataAnnotations;

namespace Senai.Svigufo.WebApi.Domains
{
    public class InstituicaoDomain
    {
        public int Id { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        [Required (ErrorMessage = "Informe o CNPJ")]
        public string CNPJ { get; set; }
        public string Logradouro { get; set; }
        public string CEP { get; set; }
        [StringLength(2, MinimumLength = 2, ErrorMessage = "UF deve conter 2 caracteres")]
        [Required(ErrorMessage = "Informe o UF, é obrigatória")]
        public string UF { get; set; }
        public string Cidade { get; set; }
    }
}