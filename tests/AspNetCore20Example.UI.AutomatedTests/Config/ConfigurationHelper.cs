using System.Configuration;
using System.IO;

namespace AspNetCore20Example.UI.AutomatedTests.Config
{
    public class ConfigurationHelper
    {
        public static string SiteUrl => ConfigurationManager.AppSettings["SiteUrl"];

        public static string RegisterUrl => string.Format("{0}{1}", SiteUrl, ConfigurationManager.AppSettings["RegisterUrl"]);

        public static string LoginUrl => string.Format("{0}{1}", SiteUrl, ConfigurationManager.AppSettings["LoginUrl"]);

        public static string ChromeDriver => string.Format("{0}{1}", FolderPath, ConfigurationManager.AppSettings["ChromeDriver"]);

        public static string TestUserName => ConfigurationManager.AppSettings["TestUserName"];

        public static string TestPassword => ConfigurationManager.AppSettings["TestPassword"];

        public static string FolderPath => Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));

        public static string FolderPicture => string.Format("{0}{1}", FolderPath, ConfigurationManager.AppSettings["FolderPicture"]);
    }
}