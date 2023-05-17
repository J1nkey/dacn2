namespace MotorcycleWebShop.Domain.Exceptions
{
    public class InvalidRegisterUserAsProviderException : Exception
    {
        public InvalidRegisterUserAsProviderException(string message)
            : base(message)
        {
        }

        public InvalidRegisterUserAsProviderException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public InvalidRegisterUserAsProviderException(string name, object key)
            : base($"Entity {name} - happen an invalid exception when register {key} as provider")
        {
        }
    }
}
