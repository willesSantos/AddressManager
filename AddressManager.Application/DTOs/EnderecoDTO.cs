using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AddressManager.Application.DTOs
{
    [Table("endereco")]
    public class EnderecoDTO
    {
        [Key]
        [MaxLength(8)]
        public int id { get; set; }

        [MaxLength(8, ErrorMessage = "Cep deve ter tamanho maximo 8 caracteres")]
        [Required(ErrorMessage = "Cep obrigatório")]
        public string cep { get; set; }

        [MaxLength(100, ErrorMessage = "Logradouro deve ter tamanho maximo de 100 caracteres")]
        [Required(ErrorMessage = "Logradouro obrigatório")]
        public string Logradouro { get; set; }

        [MaxLength(100, ErrorMessage = "Complemento deve ter tamanho maximo de 100 caracteres")]
        public string Complemento { get; set; }

        [MaxLength(100, ErrorMessage = "Bairro deve ter tamanho maximo de 100 caracteres")]
        [Required(ErrorMessage = "Bairro obrigatório")]
        public string Bairro { get; set; }

        [MaxLength(100, ErrorMessage = "Localidaded deve ter tamanho maximo de 100 caracteres")]
        public string Localidade { get; set; }

        [MaxLength(2, ErrorMessage = "Uf deve ter tamanho maximo 2 caracteres")]
        [Required(ErrorMessage = "Nome obrigatório")]
        public string Uf { get; set; }

        [MaxLength(7, ErrorMessage = "Ibge deve ter tamanho maximo de 7 caracteres")]
        public string Ibge { get; set; }

        [MaxLength(4, ErrorMessage = "Gia deve ter tamanho maximo de 4 caracteres")]
        public string Gia { get; set; }

        [MaxLength(2, ErrorMessage = "DDD deve ter tamanho maximo de 2 caracteres")]
        public string Ddd { get; set; }

        [MaxLength(4, ErrorMessage = "Siafi deve ter tamanho maximo de 4 caracteres")]
        public string Siafi { get; set; }
    }
}
