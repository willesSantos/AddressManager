using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressManagerAPI.Model
{
    [Table("endereco")]
    public class Endereco
    {
        [Key]
        [MaxLength(8)] // O tamanho máximo do CEP no banco de dados é 8.
        public string Cep { get; set; }

        [MaxLength(100)] // Tamanho máximo do logradouro.
        public string Logradouro { get; set; }

        [MaxLength(100)] // Tamanho máximo do complemento.
        public string Complemento { get; set; }

        [MaxLength(100)] // Tamanho máximo do bairro.
        public string Bairro { get; set; }

        [MaxLength(100)] // Tamanho máximo da localidade.
        public string Localidade { get; set; }

        [MaxLength(2)] // A UF é um código de 2 caracteres.
        public string Uf { get; set; }

        [MaxLength(7)] // O IBGE é um código de 7 caracteres.
        public string Ibge { get; set; }

        [MaxLength(4)] // O GIA é um código de 4 caracteres.
        public string Gia { get; set; }

        [MaxLength(2)] // O DDD é um código de 2 caracteres.
        public string Ddd { get; set; }

        [MaxLength(4)] // O SIAFI é um código de 4 caracteres.
        public string Siafi { get; set; }
    }
}
