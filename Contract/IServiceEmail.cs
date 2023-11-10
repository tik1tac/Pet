using PetProjectMarket.Shared.Model;

namespace Contract
{
    public interface IServiceEmail
    {
        Task SendEmail(EmailMetadata emaildata);
    }
}
