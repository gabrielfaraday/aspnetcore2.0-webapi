using AspNetCore20Example.UI.AutomatedTests.Config;

namespace AspNetCore20Example.UI.AutomatedTests.Login
{
    public class LoginSteps
    {
        public static void Login(SeleniumHelper browser)
        {
            browser.ClicarLinkPorTexto("Entrar");
            browser.PreencherTextBoxPorId("email", ConfigurationHelper.TestUserName);
            browser.PreencherTextBoxPorId("senha", ConfigurationHelper.TestPassword);
            browser.ClicarBotaoPorId("login");
        }
    }
}