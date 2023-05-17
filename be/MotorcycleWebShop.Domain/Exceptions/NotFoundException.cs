namespace MotorcycleWebShop.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base()
        {
        }

        public NotFoundException(string message, Exception inner)
            :base(message, inner)
        {
        }

        public NotFoundException(string name, object key)
            :base($"entity \"{name}\" ({key} was not found.)")
        {

        }
    }
}
