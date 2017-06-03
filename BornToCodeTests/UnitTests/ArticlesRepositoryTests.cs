using System;
using System.Linq;
using BornToCode.Articles;
using BornToCodeModels;
using BornToCodeTests.Core;
using NUnit.Framework;

namespace BornToCodeTests.UnitTests
{
    [TestFixture]
    public class ArticlesRepositoryTests : ContextDependent
    {
        private ArticlesRepository sut;

        public ArticlesRepositoryTests()
        {
            sut = new ArticlesRepository(base.Context);
        }

        [Test]
        public void ShouldPutNewArticle()
        {
            var articleToPut = AddArticle();
            articleToPut.Content = "TestContent2";
            sut.Put(articleToPut);
            sut.Save();
            var returnedArticle = ReturnedArticle(articleToPut);

            Assert.IsTrue(articleToPut.Id == returnedArticle.Id);
        }

        [Test]
        public void ShouldAddNewArticle()
        {
            var articleToAdd = AddArticle();
            var returnedArticle = ReturnedArticle(articleToAdd);

            Assert.IsTrue(articleToAdd == returnedArticle);
        }

        [Test]
        public void ShouldDeleteArticle()
        {
            var addedArticle = AddArticle();
            sut.Delete(addedArticle);
            sut.Save();

            Assert.Throws(Is.InstanceOf<Exception>(), () => ReturnedArticle(addedArticle));
        }

        [Test]
        public void ShouldFetchAllArticles()
        {
            var articles = sut.FetchAll();

            Assert.AreEqual(articles.Count, Context.Articles.ToList().Count);
        }

        [Test]
        public void ShouldReturnIquerable()
        {
            var articles = sut.Query();

            Assert.IsInstanceOf<IQueryable>(articles);
        }

        [Test]
        public void ShoudlNotAddInvalidArticle()
        {
            Assert.Throws(Is.InstanceOf<Exception>(), () =>
            {
                var invalidArticle = new Article(Guid.Empty, "", "");
                sut.Add(invalidArticle);
            });
        }

        [Test]
        public void ShouldNotPutInvalidArticle()
        {
            Assert.Throws(Is.InstanceOf<Exception>(), () =>
            {
                var invalidArticle = new Article(Guid.Empty, "", "");
                sut.Add(invalidArticle);
            });
        }

        private Article AddArticle()
        {
            var article = TestsConstants.BuildNewArticle();
            sut.Add(article);
            sut.Save();

            return article;
        }

        private Article ReturnedArticle(Article articleToAdd)
        {
            return sut.Query().Single(x => x.Id == articleToAdd.Id);
        }
    }
}
