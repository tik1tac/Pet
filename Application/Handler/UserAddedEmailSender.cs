using Application.Notification;
using MediatR;

namespace Application.Handler
{
    public class UserAddedEmailSender : INotificationHandler<UserAddedNotification>
    {
        private readonly IRepositoryWrapper wrapper;

        public UserAddedEmailSender(IRepositoryWrapper wrapper) => this.wrapper = wrapper;

        public async Task Handle(UserAddedNotification notification, CancellationToken cancellationToken) =>
            await wrapper.Email.SendEmail(notification.metadata);
    }
}