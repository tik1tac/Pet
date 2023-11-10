using System.Text.Json;

public class ErrorDetails
{
    public string Title { get; set; }
    public string Message { get; set; }
    public int StatusCode { get; set; }
    public IReadOnlyDictionary<string, string[]> ErrorsDictionaryValid { get; set; }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}