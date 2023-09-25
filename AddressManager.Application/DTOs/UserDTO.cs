using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressManager.Application.DTOs
{
    public class UserDTO
    {
        //public int Id { get; set; }
        [Required(ErrorMessage = "Nome obrigatório")]
        [MaxLength(255, ErrorMessage = "Tamanho maximo 255 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email obrigatório")]
        [MaxLength(255, ErrorMessage = "Tamanho maximo 255 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Email obrigatório")]
        [MinLength(8, ErrorMessage = "Tamanho minimo 8 caracteres")]
        [MaxLength(255, ErrorMessage = "Tamanho maximo 255 caracteres")]
        [NotMapped]
        public string Password { get; set; }
    }
}
