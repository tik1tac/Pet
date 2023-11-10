using Microsoft.AspNetCore.DataProtection;
using PetProjectMarket.Client.Clients;
using PetProjectMarket.Client.Services.Account;
using PetProjectMarket.Client.Services.Product;

namespace PetProjectMarket.Client.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddHttpClient(name: "MarketClient", opt =>
            {
                opt.BaseAddress = new Uri("http://localhost:5116/api/homepage");
                opt.Timeout = new TimeSpan(0, 0, 30);
                opt.DefaultRequestHeaders.Clear();
            });
            services.AddScoped<IHttpClientServiceProductImplementaion, HttpClientFactoryServiceProduct>();
            services.AddScoped<IHttpClientServiceAccountImplementation, HttpClientFactoryServiceAccount>();
            services.AddHttpClient<ProductscClient>();
            services.AddHttpClient<AccountClient>();
        }
        public static void ConfigureProtection(this IServiceCollection service)
        {
            service.AddDataProtection();
        }
    }
}
