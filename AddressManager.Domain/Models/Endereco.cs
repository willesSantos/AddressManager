using AddressManager.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AddressManager.Domain.Models
{
    [Table("endereco")]
    public class Endereco : BaseEntity
    {
        [MaxLength(8)]
        public string cep { get; set; }

        [MaxLength(100)]
        public string Logradouro { get; set; }

        [MaxLength(100)]
        public string Complemento { get; set; }

        [MaxLength(100)]
        public string Bairro { get; set; }

        [MaxLength(100)]
        public string Localidade { get; set; }

        [MaxLength(2)]
        public string Uf { get; set; }

        [MaxLength(7)]
        public string Ibge { get; set; }

        [MaxLength(4)]
        public string Gia { get; set; }

        [MaxLength(2)]
        public string Ddd { get; set; }

        [MaxLength(4)]
        public string Siafi { get; set; }
    }
}
