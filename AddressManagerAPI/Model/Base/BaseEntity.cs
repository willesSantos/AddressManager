using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AddressManagerAPI.Model.Base
{
    public class BaseEntity
    {
        public string cep { get; set; }
    }
}
