using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using static NSelene.Selene;


namespace NSeleneExamples.TodoMVC.IntegratedToSeleniumBasedFramework.AfterPlus
{
    [TestFixture]
    public class TestTodoMVC
    {
        private static readonly string ExecuteAssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        static IWebDriver driver = new ChromeDriver(ExecuteAssemblyPath);

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void FilterTasks()
        {
            var tasks = new Pages.Tasks(driver);
            tasks.Visit();

            tasks.Add("a", "b", "c");
            tasks.ShouldBe("a", "b", "c");

            tasks.Toggle("b"); 

            tasks.FilterActive();
            tasks.ShouldBe("a", "c");

            tasks.FilterCompleted();
            tasks.ShouldBe("b");

            tasks.ClearCompleted();   /* << Added with */
            tasks.ShouldBeEmpty();    /* <<  NSelene   */
        }
    }
}
