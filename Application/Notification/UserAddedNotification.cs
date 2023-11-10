using MediatR;
using PetProjectMarket.Shared.Model;

namespace Application.Notification
{
    public record UserAddedNotification(EmailMetadata metadata) : INotification;
}
