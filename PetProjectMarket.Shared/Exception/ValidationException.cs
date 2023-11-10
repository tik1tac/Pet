public class ValidationCustomException : Exception
{
    public ValidationCustomException(IReadOnlyDictionary<string, string[]> errorsdictionary)
        : base("Validation Faliure")
    {
    }

    public IReadOnlyDictionary<string, string[]> ErrorsDictionary { get; set; }
}