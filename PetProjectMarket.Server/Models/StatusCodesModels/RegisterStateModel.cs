namespace PetProject.Server.Models.StatusCodesModels
{
    public class RegisterStateModel
    {
        public bool SuccessRegister { get; set; } = false;
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
