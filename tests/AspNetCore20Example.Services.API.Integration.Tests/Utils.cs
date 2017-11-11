using AspNetCore20Example.Infra.CrossCutting.Identity.Models.AccountViewModels;
using AspNetCore20Example.Services.API.Integration.Tests.DTOs;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore20Example.Services.API.Integration.Tests
{
    public class Utils
    {
        public static async Task<Result> RealizarLoginOrganizador(HttpClient client)
        {
            var user = new LoginViewModel
            {
                Email = "user@email.com",
                Password = "123@Qa"
            };

            var postContent = GerarRequestContent(user);
            var response = await client.PostAsync("api/login", postContent);
            var userResult = JsonConvert.DeserializeObject<UsuarioJsonDTO>(await response.Content.ReadAsStringAsync());

            return userResult.data.result;
        }

        public static StringContent GerarRequestContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }
    }
}
