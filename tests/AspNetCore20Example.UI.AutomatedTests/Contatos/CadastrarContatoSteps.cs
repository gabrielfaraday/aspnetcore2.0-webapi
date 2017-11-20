using AspNetCore20Example.UI.AutomatedTests.Config;
using AspNetCore20Example.UI.AutomatedTests.Login;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;

namespace AspNetCore20Example.UI.AutomatedTests.Contatos
{
    [Binding]
    public class CadastrarContatoSteps
    {
        public SeleniumHelper Browser;

        public CadastrarContatoSteps()
        {
            Browser = SeleniumHelper.GetInstance();
        }

        [Given(@"que o usuário está no site")]
        public void DadoQueOUsuarioEstaNoSite()
        {
            Browser.NavegarPara(ConfigurationHelper.SiteUrl);
        }
        
        [Given(@"realiza o Login")]
        public void DadoRealizaOLogin()
        {
            LoginSteps.Login(Browser);
            Thread.Sleep(5000);
        }
        
        [Given(@"navega até a lista de contatos")]
        public void DadoNavegaAteAListaDeContatos()
        {
            Browser.ClicarLinkPorTexto("Contatos");
        }
        
        [Given(@"clica em novo contato")]
        public void DadoClicaEmNovoContato()
        {
            Browser.ClicarBotaoPorId("novoContato");
        }
        
        [Given(@"preenche o formulário com os valores")]
        public void DadoPreencheOFormularioComOsValores(Table table)
        {
            Browser.PreencherTextBoxPorId(table.Rows[0][0], table.Rows[0][1]);
            Browser.PreencherTextBoxPorId(table.Rows[1][0], table.Rows[1][1]);
            Browser.PreencherTextBoxPorXPath(table.Rows[2][0], table.Rows[2][1]);
            Browser.PreencherTextBoxPorId(table.Rows[3][0], table.Rows[3][1]);
            Browser.PreencherTextBoxPorId(table.Rows[4][0], table.Rows[4][1]);
            Browser.PreencherTextBoxPorId(table.Rows[5][0], table.Rows[5][1]);
            Browser.PreencherTextBoxPorId(table.Rows[6][0], table.Rows[6][1]);
            Browser.PreencherTextBoxPorId(table.Rows[7][0], table.Rows[7][1]);
            Browser.PreencherTextBoxPorId(table.Rows[8][0], table.Rows[8][1]);
            Browser.AlterarSelecaoDropDownPorId(table.Rows[9][0], table.Rows[9][1]);
        }
        
        [When(@"clicar no botao Criar")]
        public void QuandoClicarNoBotaoCriar()
        {
            Browser.ClicarBotaoPorId("adicionarContato");
            Thread.Sleep(5000);
        }
        
        [Then(@"O contato é registrado e o usuario redirecionado para a edição do contato")]
        public void EntaoOContatoERegistradoEOUsuarioRedirecionadoParaAEdicaoDoContato()
        {
            //Assert.EndsWith("contatos/alterar", Browser.ObterUrl());
            //Browser.ObterScreenShot("NovoContatoCadastrado");
        }
    }
}
