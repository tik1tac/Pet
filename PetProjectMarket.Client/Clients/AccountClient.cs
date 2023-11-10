using Microsoft.AspNetCore.DataProtection;
using PetProjectMarket.Shared.ModelDTO;
using PetProjectMarket.Shared.ModelDTO.Account;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;

namespace PetProjectMarket.Client.Clients
{
    public class AccountClient
    {
        private readonly HttpClient client;
        private readonly JsonSerializerOptions options;
        private readonly IDataProtector protector;

        public AccountClient(HttpClient _client, IDataProtectionProvider provider)
        {
            client = _client;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            protector = provider.CreateProtector("AccountKey");

            client.BaseAddress = new Uri("http://localhost:5116/account");
            client.Timeout = new TimeSpan(0, 0, 30);
            client.DefaultRequestHeaders.Clear();
        }
        public async Task Register(UserRegistration user)
        {
            //client.BaseAddress = new Uri("http://localhost:5116/api/Register");
            var content = JsonSerializer.Serialize(user);

            //var protectcontent = protector.Protect(content);
            var body = new StringContent(content, encoding: Encoding.UTF8, "application/json");

            var postResult = await client.PostAsync("account/Register", body);
            var postContent = await postResult.Content.ReadAsStringAsync();

            postResult.EnsureSuccessStatusCode();
        }

        public async Task Login(UserLogin user)
        {
            //client.BaseAddress = new Uri("http://localhost:5116/api/Login");
            var content = JsonSerializer.Serialize(user);
            //var protectcontent = protector.Protect(content);

            var body = new StringContent(content, encoding: Encoding.UTF8, "application/json");
            var postResult = await client.PostAsync("account/Login", body);

            var postContent = await postResult.Content.ReadAsStringAsync();

            postResult.EnsureSuccessStatusCode();
        }
        public async Task Logout()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "account/Logout");
            var postResult = await client.SendAsync(request);
            var postContent = await postResult.Content.ReadAsStringAsync();
            postResult.EnsureSuccessStatusCode();
        }
        //public async Task ResetPassword(ResetPassword reset)
        //{
        //    var 
        //}
        //public async Task ForgotPassword(ForgotPassword forgot)
        //{

        //}
        //public async Task ConfirmEmail()
        //{
        //    //TODO API ConfirmEmail
        //}
    }
}
