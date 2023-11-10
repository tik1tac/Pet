using Application.Notification;
using MediatR;

namespace Application.Handler
{
    public class ResetPasswordEmailSender : INotificationHandler<ResetPasswordUserNotification>
    {
        private readonly IRepositoryWrapper wrapper;
        public ResetPasswordEmailSender(IRepositoryWrapper _wrapper) => wrapper = _wrapper;
        public async Task Handle(ResetPasswordUserNotification notification, CancellationToken cancellationToken) =>
            await wrapper.Email.SendEmail(notification.email);

    }
}
