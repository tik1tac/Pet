namespace PetProject.Server.Models.StatusCodesModels
{
    public class ConfirmEmailModel
    {
        public bool SuccessConfirm { get; set; } = false;
        public string ErrorConfirm { get; set; } = string.Empty;
    }
}
