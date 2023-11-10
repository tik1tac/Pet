using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;

using Microsoft.AspNetCore.WebUtilities;

using PetProjectMarket.Shared.Helpers;
using PetProjectMarket.Shared.ModelDTO.Product;

namespace PetProjectMarket.Client.Clients
{
    public class ProductscClient
    {
        private readonly HttpClient productclient;
        private readonly JsonSerializerOptions jsonserializer;
        public ProductscClient(HttpClient productclient)
        {
            this.productclient = productclient;
            jsonserializer = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            productclient.BaseAddress = new Uri("http://localhost:5116/api/products");
            productclient.Timeout = new TimeSpan(0, 0, 30);
            productclient.DefaultRequestHeaders.Clear();
        }

        public async Task<PagingResponse<ProductsEntity>> GetProducts(ProductsParametres parametr)
        {
            var queryParam = new Dictionary<string, string>
            {
                ["PageNumber"] = parametr.PageNumber.ToString()
            };
            var response = await productclient.GetAsync(QueryHelpers.AddQueryString("product/GetProduct", queryParam));
            var content = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();

            var PageList = new PagingResponse<ProductsEntity>
            {
                Items = JsonSerializer.Deserialize<List<ProductsEntity>>(content),
                Metadata = JsonSerializer.Deserialize<Metadata>(response.Headers.GetValues("Pagination").First())
            };

            return PageList;
        }

        public async Task CreateProducts(CreateProductDTO product)
        {
            var content = JsonSerializer.Serialize(product);
            var body = new StringContent(content, Encoding.UTF8, "application/json");

            var postResult = await productclient.PostAsync("product/CreateProduct", body);
            var postContent = await postResult.Content.ReadAsStringAsync();

            postResult.EnsureSuccessStatusCode();

            var productCreated = JsonSerializer.Deserialize<CreateProductDTO>(postContent, jsonserializer);
        }

        public async Task UpdateProduct(UpdateProducts products)
        {
            var content = JsonSerializer.Serialize(products);
            var body = new StringContent(content, Encoding.UTF8, "application/json");

            var uri = Path.Combine("product/UpadteProduct", products.Id.ToString());

            var response = await productclient.PostAsync(uri, body);
            var contentPut = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProduct(DeleteProduct product)
        {
            var uri = Path.Combine("product/DeleteProduct", product.Id.ToString());
            var response = await productclient.DeleteAsync(uri);

            response.EnsureSuccessStatusCode();
        }

    }
}
