using Application.Notification;
using MediatR;

namespace Application.Handler
{
    public class LockedUserEmailSender : INotificationHandler<LockedUserNotification>
    {
        private readonly IRepositoryWrapper wrapper;
        public LockedUserEmailSender(IRepositoryWrapper _wrapper)=>wrapper = _wrapper;
        public Task Handle(LockedUserNotification notification, CancellationToken cancellationToken) =>
            wrapper.Email.SendEmail(notification.email);
    }
}
