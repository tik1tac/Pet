using PetProjectMarket.Client.Clients;
using PetProjectMarket.Shared.ModelDTO.Account;

namespace PetProjectMarket.Client.Services.Account
{
	public class HttpClientFactoryServiceAccount : IHttpClientServiceAccountImplementation
	{
		private readonly AccountClient client;
		public HttpClientFactoryServiceAccount(AccountClient _client) => client = _client;
		//public Task ConfirmEmail()
		//{
		//    throw new NotImplementedException();
		//}

		//public Task ForgotPassword()
		//{
		//    throw new NotImplementedException();
		//}

		public async Task Login(UserLogin userLogin) => await client.Login(userLogin);

		public async Task Logout() => await client.Logout();

		public async Task Register(UserRegistration userRegistration) => await client.Register(userRegistration);

		//public Task ResetPassword()
		//{
		//    throw new NotImplementedException();
		//}
	}
}
