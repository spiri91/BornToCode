using System;
using BornToCode;
using BornToCode.DataBaseFunctions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace BornToCodeTests.Core
{
    public abstract class WebDriverDependent
    {
        public IWebDriver driver;
        private DebugTestDataSeed Dbts;
        private BornToCodeContext Context;

        public WebDriverDependent()
        {
            driver = new ChromeDriver(@"F:\BornToCode\BornToCodeTests\");
            Context = new BornToCodeContext();
            Dbts = new DebugTestDataSeed(Context);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }

        [SetUp]
        protected void BeforeEachTest()
        {
            Dbts.DeleteAll();
            Dbts.Seed();
            Context.SaveChanges();
            driver.Navigate().GoToUrl(TestsConstants.Url);
        }

        [TearDown]
        protected void AfterEachTest()
        {
            Dbts.DeleteAll();
        }

        ~WebDriverDependent()
        {
            Context.Dispose();
        }
    }
}
