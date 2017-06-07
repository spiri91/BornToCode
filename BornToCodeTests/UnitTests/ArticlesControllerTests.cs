using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using BornToCode.Controllers;
using BornToCode.Core.Contracts;
using BornToCode.ExceptionHandling.Exceptions;
using BornToCodeModels;
using Moq;
using NUnit.Framework;

namespace BornToCodeTests.UnitTests
{
    class ArticlesControllerTests
    {
        private Mock<IRepository<Article>> repositoryMock;
        private Mock<IUnitOfWork> unitOfWorkMock; 
        private ArticlesController sut;
        private List<Article> articlesList;
        private Article testArticle;

        [SetUp]
        public void SetUp()
        {
            testArticle = TestsConstants.BuildNewArticle();
            articlesList = new List<Article>() { testArticle };

            unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(x => x.SaveState(It.IsAny<IRepository<Article>>(), It.IsAny<Action>()));

            repositoryMock = new Mock<IRepository<Article>>();
            repositoryMock.Setup(x => x.FetchAll()).Returns(articlesList);
            repositoryMock.Setup(x => x.Query()).Returns(articlesList.AsQueryable());
            repositoryMock.Setup(x => x.Add(It.IsAny<Article>()));
            repositoryMock.Setup(x => x.Put(It.IsAny<Article>()));
            repositoryMock.Setup(x => x.Delete(It.IsAny<Article>()));

            sut = new ArticlesController(repositoryMock.Object, unitOfWorkMock.Object);
        }

        [Test]
        public void ShouldGetAllArticles()
        {
            var result = sut.Get();
            Assert.IsInstanceOf<IQueryable>(result);
            repositoryMock.Verify(x => x.Query(), Times.Once);
        }

        [Test]
        public void ShouldGetSingleResult()
        {
            var result = sut.Get(testArticle.Id);
            Assert.IsInstanceOf<SingleResult>(result);
            repositoryMock.Verify(x => x.Query(), Times.Once);
        }

        [Test]
        public void ShouldPostAnArticle()
        {
            sut.Post(testArticle);
            repositoryMock.Verify(x => x.Add(It.IsAny<Article>()), Times.Once);
            unitOfWorkMock.Verify(x => x.SaveState(It.IsAny<IRepository<Article>>(), It.IsAny<Action>()), Times.Once);
        }

        [Test]
        public void ShouldPutAnArticle()
        {
            sut.Put(testArticle.Id, testArticle);
            repositoryMock.Verify(x => x.Put(It.IsAny<Article>()), Times.Once);
            unitOfWorkMock.Verify(x => x.SaveState(It.IsAny<IRepository<Article>>(), It.IsAny<Action>()), Times.Once);
        }

        [Test]
        public void ShouldDeleteAnArticle()
        {
            sut.Delete(testArticle.Id);
            repositoryMock.Verify(x => x.Delete(It.IsAny<Article>()), Times.Once);
            unitOfWorkMock.Verify(x => x.SaveState(It.IsAny<IRepository<Article>>(), It.IsAny<Action>()), Times.Once);
        }

        [Test]
        public void ShouldReturnEmptyOnGettingArticleWithInvalidKey()
        {
            Assert.AreEqual(0, sut.Get(Guid.Empty).Queryable.Count());
        }

        [Test]
        public void ShouldThrowErrorOnPostingInvalidArticle()
        {
            Assert.Throws<BadFormat>(() => sut.Post(new Article(Guid.Empty, "", "", "")));
        }

        [Test]
        public void SouldThrowErrorOnPuttingInvalidArticle()
        {
            Assert.IsInstanceOf<BadRequestResult>(sut.Put(Guid.NewGuid(), testArticle));
            Assert.IsInstanceOf<BadRequestResult>(sut.Put(testArticle.Id, TestsConstants.BuildNewArticle()));
        }

        [Test]
        public void ShouldThrowErrorOnDeletingArticleWithInvalidKey()
        {
            Assert.IsInstanceOf<NotFoundResult>(sut.Delete(Guid.NewGuid()));
            Assert.IsInstanceOf<NotFoundResult>(sut.Delete(Guid.Empty));
        }
    }
}
