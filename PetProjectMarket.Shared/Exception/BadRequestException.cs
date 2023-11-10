public class BadRequestCustomException : Exception
{
    protected BadRequestCustomException(string? message)
        : base(message)
    {

    }
}