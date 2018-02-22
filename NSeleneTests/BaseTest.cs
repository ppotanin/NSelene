using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using static NSelene.Selene;


namespace NSeleneTests
{

    [TestFixture]
    public class BaseTest
    {
        private static readonly string ExecuteAssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        static IWebDriver driver = new ChromeDriver(ExecuteAssemblyPath);
        [OneTimeSetUp]
        public void initDriver()
        {
            SetWebDriver(driver);
        }

        [OneTimeTearDown]
        public void disposeDriver()
        {
            GetWebDriver().Quit();
        }
    }
}
