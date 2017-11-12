using AspNetCore20Example.Infra.CrossCutting.Identity.Models.AccountViewModels;
using AspNetCore20Example.Services.API.Integration.Tests.Configuration;
using AspNetCore20Example.Services.API.Integration.Tests.DTOs;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace AspNetCore20Example.Services.API.Integration.Tests.Controllers
{
    public class AccountControllerIntegrationTest : BaseIntegrationTest
    {
        public AccountControllerIntegrationTest(BaseTestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task Registrar_UsuarioValido_DeveRetornar200_E_TokenDoUsuario()
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

            var response = await Client.PostAsync("api/registrar", postContent);
            response.EnsureSuccessStatusCode();

            var registrarResult = JsonConvert.DeserializeObject<UsuarioJsonDTO>(await response.Content.ReadAsStringAsync());
            Assert.NotEmpty(registrarResult.data.result.access_token);
        }

        [Fact]
        public async Task Registrar_UsuarioInvalido_DeveRetornar400()
        {
            var usuario = new RegisterViewModel
            {
                Nome = "User",
                CPF = "39581132813",
                Email = "user",
                Password = "123@Qa",
                ConfirmPassword = "123@Qa"
            };

            var postContent = Utils.GerarRequestContent(usuario);

            var response = await Client.PostAsync("api/registrar", postContent);
            Assert.Equal(response.StatusCode, HttpStatusCode.BadRequest);

            var result = JsonConvert.DeserializeObject<BadRequestJsonDTO>(await response.Content.ReadAsStringAsync());
            Assert.True(result.errors.Any(x => x == "O e-mail informado é inválido"));
        }
    }
}