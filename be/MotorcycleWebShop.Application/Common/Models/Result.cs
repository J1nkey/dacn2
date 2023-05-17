namespace MotorcycleWebShop.Application.Common.Models
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Messagee { get; set; }
        public string[] Errors { get; init; }

        internal Result(bool succeeded, IEnumerable<string> errors)
        {
            IsSuccess = succeeded;
            Errors = errors.ToArray();
        }

        public static Result Succeeded()
        {
            return new Result(true, Array.Empty<string>());
        }

        public static Result Failure(IEnumerable<string> errors)
        {
            return new Result(false, errors);
        }
    }
}
