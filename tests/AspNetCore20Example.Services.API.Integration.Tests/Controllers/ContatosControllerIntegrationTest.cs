using AspNetCore20Example.Application.ViewModels;
using AspNetCore20Example.Domain.Contatos.Entities;
using AspNetCore20Example.Services.API.Integration.Tests.Configuration;
using AspNetCore20Example.Services.API.Integration.Tests.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace AspNetCore20Example.Services.API.Integration.Tests.Controllers
{
    public class ContatosControllerIntegrationTest : BaseIntegrationTest
    {
        public ContatosControllerIntegrationTest(BaseTestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task Post_ContatoValido_DeveRetornar200()
        {
            var login = await Utils.RealizarLogin(Client);

            var contato = new ContatoViewModel
            {
                Nome = "Teste",
                Email = "teste@teste.com",
                Endereco = new EnderecoViewModel
                {
                    Logradouro = "Rua 1",
                    Bairro = "bairro",
                    CEP = "14778665",
                    Cidade = "cidade",
                    Estado = "SP",
                    Numero = "123"
                }
            };

            var response = await Server
                .CreateRequest("api/contatos")
                .AddHeader("Authorization", "Bearer " + login.access_token)
                .And(req => req.Content = Utils.GerarRequestContent(contato))
                .PostAsync();

            response.EnsureSuccessStatusCode();

            var contatoResult = JsonConvert.DeserializeObject<ContatoJsonDTO>(await response.Content.ReadAsStringAsync());

            Assert.Equal(contatoResult.data.nome, contato.Nome);
            Assert.NotEmpty(contatoResult.data.id);
            Assert.NotNull(contatoResult.data.id);
            Assert.NotEmpty(contatoResult.data.enderecoId);
            Assert.NotNull(contatoResult.data.enderecoId);
        }

        [Fact]
        public async Task Post_SemAutenticacao_DeveRetornar401()
        {
            var contato = new ContatoViewModel();

            var response = await Server
                .CreateRequest("api/contatos")
                .And(req => req.Content = Utils.GerarRequestContent(contato))
                .PostAsync();

            Assert.Equal(response.StatusCode, HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task Get_SemEspecificarId_DeveRetornarTodosContatosAtivos()
        {
            var contato1 = new Contato(Guid.NewGuid(), "Teste", "teste@teste.com", new DateTime(2010, 12, 10));
            contato1.AtivarContato(Guid.NewGuid());
            contato1.AtribuirEndereco(new Endereco(Guid.NewGuid(), "Rua 1", "123", null, "bairro", "14778665", "cidade", "SP"));

            var contato2 = new Contato(Guid.NewGuid(), "Teste", "teste@teste.com", new DateTime(2010, 12, 10));
            contato2.AtribuirEndereco(new Endereco(Guid.NewGuid(), "Rua 1", "123", null, "bairro", "14778665", "cidade", "SP"));

            TestMainContext.Add(contato1);
            TestMainContext.Add(contato2);
            TestMainContext.SaveChanges();

            var response = await Client.GetAsync("api/contatos");
            response.EnsureSuccessStatusCode();

            var retorno = JsonConvert.DeserializeObject<List<ContatoDTO>>(await response.Content.ReadAsStringAsync());

            Assert.Equal(retorno.Count, 1);
            Assert.Contains(retorno, x => x.nome == contato1.Nome);
        }

        [Fact]
        public async Task Get_ComIdEspecificado_DeveRetornarRegistroDesejado()
        {
            var login = await Utils.RealizarLogin(Client);

            var contato1 = new Contato(Guid.NewGuid(), "Teste", "teste@teste.com", new DateTime(2010, 12, 10));
            contato1.AtivarContato(Guid.NewGuid());
            contato1.AtribuirEndereco(new Endereco(Guid.NewGuid(), "Rua 1", "123", null, "bairro", "14778665", "cidade", "SP"));

            var contatoIdDesejado = Guid.NewGuid();

            var contato2 = new Contato(contatoIdDesejado, "Teste", "teste@teste.com", new DateTime(2010, 12, 10));
            contato2.AtivarContato(Guid.NewGuid());
            contato2.AtribuirEndereco(new Endereco(Guid.NewGuid(), "Rua 1", "123", null, "bairro", "14778665", "cidade", "SP"));

            TestMainContext.Add(contato1);
            TestMainContext.Add(contato2);
            TestMainContext.SaveChanges();

            var response = await Server
                .CreateRequest($"api/contatos/{contatoIdDesejado}")
                .AddHeader("Authorization", "Bearer " + login.access_token)
                .GetAsync();

            response.EnsureSuccessStatusCode();

            var retorno = JsonConvert.DeserializeObject<ContatoDTO>(await response.Content.ReadAsStringAsync());

            Assert.NotNull(retorno);
            Assert.Equal(retorno.nome, contato2.Nome);
        }

        [Fact]
        public async Task Put_ContatoValido_DeveRetornar200()
        {
            var login = await Utils.RealizarLogin(Client);

            var contatoId = Guid.NewGuid();
            var enderecoId = Guid.NewGuid();
            var ativadoPor = Guid.NewGuid();

            var contato = new Contato(contatoId, "Teste", "teste@teste.com", new DateTime(2010, 12, 10));
            contato.AtivarContato(ativadoPor);
            contato.AtribuirEndereco(new Endereco(enderecoId, "Rua 1", "123", null, "bairro", "14778665", "cidade", "SP"));

            TestMainContext.Add(contato);
            TestMainContext.SaveChanges();

            var contatoVM = new ContatoViewModel
            {
                Id = contatoId,
                Nome = "Alterado",
                Email = "teste@teste.com",
                EnderecoId = enderecoId,
                AtivadoPor = ativadoPor,
                Endereco = new EnderecoViewModel
                {
                    Id = enderecoId,
                    Logradouro = "Rua 1",
                    Bairro = "bairro",
                    CEP = "14778665",
                    Cidade = "cidade",
                    Estado = "SP",
                    Numero = "123"
                }
            };

            var response = await Server
                .CreateRequest("api/contatos")
                .AddHeader("Authorization", "Bearer " + login.access_token)
                .And(req => req.Content = Utils.GerarRequestContent(contatoVM))
                .SendAsync("PUT");

            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<ContatoJsonDTO>(await response.Content.ReadAsStringAsync());

            Assert.Equal(result.data.nome, contatoVM.Nome);
            Assert.NotEmpty(result.data.id);
            Assert.NotNull(result.data.id);
            Assert.NotEmpty(result.data.enderecoId);
            Assert.NotNull(result.data.enderecoId);
        }

        [Fact]
        public async Task Delete_ComIdExistente_DeveRetornar200()
        {
            var login = await Utils.RealizarLogin(Client);

            var contatoId = Guid.NewGuid();

            var contato = new Contato(contatoId, "Teste", "teste@teste.com", new DateTime(2010, 12, 10));
            contato.AtivarContato(Guid.NewGuid());
            contato.AtribuirEndereco(new Endereco(Guid.NewGuid(), "Rua 1", "123", null, "bairro", "14778665", "cidade", "SP"));

            TestMainContext.Add(contato);
            TestMainContext.SaveChanges();

            var response = await Server
                .CreateRequest($"api/contatos/{contatoId}")
                .AddHeader("Authorization", "Bearer " + login.access_token)
                .SendAsync("DELETE");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Delete_ComIdInexistente_DeveRetornar500()
        {
            var login = await Utils.RealizarLogin(Client);

            var response = await Server
                .CreateRequest($"api/contatos/{Guid.NewGuid()}")
                .AddHeader("Authorization", "Bearer " + login.access_token)
                .SendAsync("DELETE");

            Assert.Equal(response.StatusCode, HttpStatusCode.InternalServerError);
        }
    }
}
