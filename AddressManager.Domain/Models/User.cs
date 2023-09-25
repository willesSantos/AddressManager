using AddressManager.Domain.Validation;

namespace AddressManager.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public User(){}

        public User(int id, string name, string email)
        {
            DomainExceptionValidation.When(id < 0, "id não pode ser menos que zero");
            Id = id;
            ValidateDomain(name, email);
        }

        public User(string name, string email)
        {
            ValidateDomain(name, email);
        }

        public void ValidateDomain(string nome, string email)
        {
            DomainExceptionValidation.When(nome.Length > 10, "Nome não pode ser maior que 100 caracteres");
            DomainExceptionValidation.When(email.Length > 100, "Email não pode ser maior que 100 caracteres");
            DomainExceptionValidation.When(email == null, "Email não pode ser nulo");
            DomainExceptionValidation.When(nome == null, "Nome não pode ser nulo");
            Name = nome;
            Email = email;
        }
    }
}
