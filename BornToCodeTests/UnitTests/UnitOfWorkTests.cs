using BornToCode.Core;
using BornToCode.Core.Contracts;
using BornToCodeModels;
using Moq;
using NUnit.Framework;

namespace BornToCodeTests.UnitTests
{
    [TestFixture]
    public class UnitOfWorkTests
    {
        private Mock<IRepository<Article>> repositoryMock;
        private UnitOfWork sut;

        public UnitOfWorkTests()
        {
            repositoryMock = new Mock<IRepository<Article>>();
            sut = new UnitOfWork();
        }

        [Test]
        public void ShouldCallSaveOnRepo()
        {
            sut.SaveState(repositoryMock.Object);
            repositoryMock.Verify(x => x.Save(), Times.Once);
        }
    }
}
