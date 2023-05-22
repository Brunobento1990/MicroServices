using Domain.Entities;

namespace Domain.Validations
{
    public class DomainExceptionValidationsString : Exception
    {
        public DomainExceptionValidationsString(string error) : base(error) { }
        
        public static void When(bool hasError,string error)
        {
            if (hasError)
                throw new DomainExceptionValidationsString(error);
        }
    }
}
