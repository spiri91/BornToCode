using System;
using BornToCode.ExceptionHandling.Exceptions;
using BornToCodeModels;
using NUnit.Framework;

namespace BornToCodeTests.UnitTests
{
    [TestFixture]
    public class ArticlesTests
    {
        [Test]
        public void ShouldCreateANewArticle()
        {
            var article = new Article(Guid.NewGuid(), TestsConstants.Title, TestsConstants.Content);
        }

        [Test]
        public void ShouldNotCreateANewArticle_EmptyGuid()
        {
           Assert.Throws(Is.InstanceOf<BadFormat>(),
               () => { var article = new Article(Guid.Empty, TestsConstants.Title, TestsConstants.Content); });
        }

        [Test]
        public void ShouldNotCreateANewArticle_EmptyTitleAndContent()
        {
            Assert.Throws(Is.InstanceOf<BadFormat>(),
               () => { var article = new Article(Guid.NewGuid(), "", "null"); });
        }
    }
}
