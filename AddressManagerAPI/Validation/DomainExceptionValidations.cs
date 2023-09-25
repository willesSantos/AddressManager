using AddressManager.Domain.Validation;

namespace AddressManagerAPI.Validation
{
    public class DomainExceptionValidations : Exception
    {
        public DomainExceptionValidations(string error) : base(error) { }
        public static void When(bool hasError, string error)
        {
            if (hasError)
            {
                throw new DomainExceptionValidation(error);
            }
        }
    }
}
