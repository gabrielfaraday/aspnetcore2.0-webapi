﻿using AspNetCore20Example.Infra.CrossCutting.Identity.Models.AccountViewModels;
using AspNetCore20Example.Services.API.Integration.Tests.Configuration;
using AspNetCore20Example.Services.API.Integration.Tests.DTOs;
using Newtonsoft.Json;
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
            var registrarResult = JsonConvert.DeserializeObject<UsuarioJsonDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.NotEmpty(registrarResult.data.result.access_token);
        }
    }
}