using AspNetCore20Example.UI.AutomatedTests.Config;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;

namespace AspNetCore20Example.UI.AutomatedTests.Account
{
    [Binding]
    public class CadastrarUsuarioSteps
    {
        public SeleniumHelper Browser;

        public CadastrarUsuarioSteps()
        {
            Browser = SeleniumHelper.GetInstance();
        }

        [Given(@"que o usuário está na tela inicial do site")]
        public void DadoQueOUsuarioEstaNaTelaInicialDoSite()
        {
            Browser.NavegarPara(ConfigurationHelper.SiteUrl);
        }
        
        [Given(@"clica no link para se registrar")]
        public void DadoClicaNoLinkParaSeRegistrar()
        {
            Browser.ClicarLinkPorTexto("Registre-se");
        }
        
        [Given(@"preenche os campos com os valores")]
        public void DadoPreencheOsCamposComOsValores(Table table)
        {
            Browser.PreencherTextBoxPorId(table.Rows[0][0], table.Rows[0][1]);
            Browser.PreencherTextBoxPorId(table.Rows[1][0], table.Rows[1][1]);
            Browser.PreencherTextBoxPorId(table.Rows[2][0], table.Rows[2][1]);
            Browser.PreencherTextBoxPorId(table.Rows[3][0], table.Rows[3][1]);
            Browser.PreencherTextBoxPorId(table.Rows[4][0], table.Rows[4][1]);
        }
        
        [When(@"clicar no botão Registrar")]
        public void QuandoClicarNoBotaoRegistrar()
        {
            Browser.ClicarBotaoPorId("registrar");
        }
        
        [Then(@"será registrado e será redirecionado com sucesso")]
        public void EntaoSeraRegistradoESeraRedirecionadoComSucesso()
        {
            Thread.Sleep(5000);
            var returnText = Browser.ObterTextoElementoPorId("saudacaoUsuario");
            Assert.Contains("olá usuario teste", returnText.ToLower());
            Browser.ObterScreenShot("EvidenciaCadastroUsuario");
        }

        // **************************** Cenários de falha  ******************************

        [Then(@"Recebe uma mensagem de erro de CPF já cadastrado")]
        public void EntaoRecebeUmaMensagemDeErroDeCPFJaCadastrado()
        {
            var result = Browser.ObterTextoElementoPorClasse("alert-danger");
            Assert.Contains("o cpf informado já foi cadastrado anteriormente.", result.ToLower());

            Browser.ObterScreenShot("CPF_Erro");
        }

        [Then(@"recebe uma mensagem de erro de email já cadastrado")]
        public void EntaoRecebeUmaMensagemDeErroDeEmailJaCadastrado()
        {
            var result = Browser.ObterTextoElementoPorClasse("alert-danger");
            Assert.Contains("is already taken", result.ToLower());

            Browser.ObterScreenShot("Email_Erro");
        }

        [Then(@"Recebe uma mensagem de erro de que a senha esta em tamanho inferior ao permitido")]
        public void EntaoRecebeUmaMensagemDeErroDeQueASenhaEstaEmTamanhoInferiorAoPermitido()
        {
            var result = Browser.ObterTextoElementoPorClasse("text-danger");
            Assert.Contains("a senha deve possuir no mínimo 4 caracteres", result.ToLower());
        }

        [Then(@"Recebe uma mensagem de erro de que a senha estao diferentes")]
        public void EntaoRecebeUmaMensagemDeErroDeQueASenhaEstaoDiferentes()
        {
            var result = Browser.ObterTextoElementoPorClasse("text-danger");
            Assert.Contains("as senhas não conferem", result.ToLower());
        }
    }
}
