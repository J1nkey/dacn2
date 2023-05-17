namespace MotorcycleWebShop.Domain.Exceptions
{
    public class UserExistedException : Exception
    {
        public UserExistedException(string message)
            :base(message)
        {
        }

        public UserExistedException(string message, Exception innerException)
            :base(message, innerException)
        {
        }

        public UserExistedException(string name, object key)
            :base($"Entity \"{name}\" ({key} is existed)")
        {
        }
    }
}
