using BornToCodeTests.Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BornToCodeTests.BehaviourTests
{

    [Ignore("not implemented")]
    [TestFixture]
    public class CrudIntegrationTests : WebDriverDependent
    {
        [Test]
        public void Should_show_articles()
        {
            int numberOfArticles = driver.FindElements(By.CssSelector("article")).Count;
            Assert.IsTrue(numberOfArticles > 0);
        }

        [Test]
        public void Should_add_article()
        {
            
        }

        [Test]
        public void Should_edit_article()
        {
            
        }
    }
}
