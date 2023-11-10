namespace PetProjectMarket.Client.Models
{
    public class ErrorViewModel
    {
        public string TextError { get; set; }

        public string StatusCode { get; set; }

        public ErrorViewModel(string textError, string statuscode)
        {
            TextError = textError;
            StatusCode = statuscode;
        }
    }
}