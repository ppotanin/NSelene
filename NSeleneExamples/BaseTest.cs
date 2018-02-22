using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static NSelene.Selene;


namespace NSeleneExamples
{
    [TestFixture()]
    public class BaseTest
    {
        private static readonly string ExecuteAssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        static IWebDriver driver = new ChromeDriver(ExecuteAssemblyPath);
        [SetUp]
        public void SetupTest()
        {
            SetWebDriver(driver);
        }

        [TearDown]
        public void TeardownTest()
        {
            GetWebDriver().Quit();
        }
    }
}
