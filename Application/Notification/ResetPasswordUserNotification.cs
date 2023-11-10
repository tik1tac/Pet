using MediatR;
using PetProjectMarket.Shared.Model;

namespace Application.Notification
{
    public record ResetPasswordUserNotification(EmailMetadata email) : INotification;
}
