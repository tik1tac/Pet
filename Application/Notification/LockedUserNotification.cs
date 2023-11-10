using MediatR;
using PetProjectMarket.Shared.Model;

namespace Application.Notification
{
    public record LockedUserNotification(EmailMetadata email) : INotification;

}
