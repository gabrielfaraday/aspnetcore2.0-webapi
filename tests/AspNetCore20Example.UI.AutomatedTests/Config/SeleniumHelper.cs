using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace AspNetCore20Example.UI.AutomatedTests.Config
{
    public class SeleniumHelper
    {
        public static IWebDriver ChromeDriver;
        public WebDriverWait Wait;

        private static SeleniumHelper _instance;

        protected SeleniumHelper()
        {
            ChromeDriver = new ChromeDriver(ConfigurationHelper.ChromeDriver);
            Wait = new WebDriverWait(ChromeDriver, TimeSpan.FromSeconds(30));
        }

        public static SeleniumHelper GetInstance()
        {
            return _instance ?? (_instance = new SeleniumHelper());
        }

        public string ObterUrl()
        {
            return ChromeDriver.Url;
        }

        public bool ValidarConteudoUrl(string conteudo)
        {
            return Wait.Until(ExpectedConditions.UrlContains(conteudo));
        }

        public string NavegarPara(string url)
        {
            ChromeDriver.Navigate().GoToUrl(url);
            return ObterUrl();
        }

        public void ClicarLinkPorTexto(string texto)
        {
            var link = Wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(texto)));
            link.Click();
        }

        public void ClicarBotaoPorId(string id)
        {
            var botao = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
            botao.Click();
        }

        public void PreencherTextBoxPorId(string id, string valor)
        {
            var textBox = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
            textBox.SendKeys(valor);
        }

        public void PreencherTextBoxPorXPath(string xpath, string valor)
        {
            var textbox = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            textbox.SendKeys(valor);
        }

        public void AlterarSelecaoDropDownPorId(string id, string valor)
        {
            var dropDown = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
            var itemSelecionado = new SelectElement(dropDown);
            itemSelecionado.SelectByValue(valor);
        }
        public string ObterTextoElementoPorClasse(string className)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(className))).Text;
        }

        public string ObterTextoElementoPorId(string id)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id))).Text;
        }

        public IEnumerable<IWebElement> ObterItensPorClasse(string className)
        {
            return Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName(className)));
        }

        public void ObterScreenShot(string nome)
        {
            var screenshot = ((ITakesScreenshot)ChromeDriver).GetScreenshot();
            SalvarScreenShot(screenshot, string.Format("{0}_" + nome + ".png", DateTime.Now.ToFileTime()));
        }

        private static void SalvarScreenShot(Screenshot screenshot, string nomeArquivo)
        {
            screenshot.SaveAsFile(
                string.Format("{0}{1}", ConfigurationHelper.FolderPicture, nomeArquivo),
                ScreenshotImageFormat.Png);
        }
    }
}
