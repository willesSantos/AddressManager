using System.ComponentModel.DataAnnotations;

namespace AddressManager.Domain.Models.Base
{
    public class BaseEntity
    {
        [Key]
        [MaxLength(8)]
        public int id { get; set; }
    }
}
