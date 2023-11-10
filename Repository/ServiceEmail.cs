using Contract;
using FluentEmail.Core;
using PetProjectMarket.Shared.Model;

namespace Repository
{
    public class ServiceEmail : IServiceEmail
    {
        private readonly IFluentEmail fluentemail;
        public ServiceEmail(IFluentEmail fluentemail) => this.fluentemail = fluentemail;

        public async Task SendEmail(EmailMetadata emaildata)
        {
            await fluentemail.To(emaildata.AddressTo)
                .Subject(emaildata.Subject)
                .Body(emaildata.Body)
                .SendAsync();
        }
    }
}
