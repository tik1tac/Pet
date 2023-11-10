namespace PetProject.Server.Models.StatusCodesModels
{
    public class LoginModel
    {
        public bool SuccessAuth { get; set; } = false;
        public string ErrorAuth { get; set; } = string.Empty;
        public string Token { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
