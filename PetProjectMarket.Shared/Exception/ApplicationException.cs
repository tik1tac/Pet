public class ApplicationExceptionCustom : Exception
{
    protected ApplicationExceptionCustom(string title, string message)
        : base(message) => Title = title;

    public string Title { get; set; }
}