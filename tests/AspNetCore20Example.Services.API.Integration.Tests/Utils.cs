using AspNetCore20Example.Infra.CrossCutting.Identity.Models.AccountViewModels;
using AspNetCore20Example.Services.API.Integration.Tests.DTOs;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetCore20Example.Services.API.Integration.Tests
{
    public class Utils
    {
        public static async Task<Result> RealizarLogin(HttpClient client)
        {
            var usuario = new LoginViewModel
            {
                Email = "user@email.com",
                Password = "123@Qa"
            };

            var postContent = GerarRequestContent(usuario);
            var response = await client.PostAsync("api/login", postContent);
            var loginResult = JsonConvert.DeserializeObject<UsuarioJsonDTO>(await response.Content.ReadAsStringAsync());


            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return await RegistrarUsuario(client);

            response.EnsureSuccessStatusCode();
            Assert.NotNull(loginResult.data.result);
            Assert.NotEmpty(loginResult.data.result.access_token);

            return loginResult.data.result;
        }

        public static async Task<Result> RegistrarUsuario(HttpClient client)
        {
            var usuario = new RegisterViewModel
            {
                Nome = "User",
                CPF = "39581132813",
                Email = "user@email.com",
                Password = "123@Qa",
                ConfirmPassword = "123@Qa"
            };

            var postContent = Utils.GerarRequestContent(usuario);
            var response = await client.PostAsync("api/registrar", postContent);
            var registrarResult = JsonConvert.DeserializeObject<UsuarioJsonDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.NotNull(registrarResult.data.result);
            Assert.NotEmpty(registrarResult.data.result.access_token);

            return registrarResult.data.result;
        }

        public static StringContent GerarRequestContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }
    }
}
