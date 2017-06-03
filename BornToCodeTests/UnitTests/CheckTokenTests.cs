using BornToCode.Core;
using BornToCodeTests.Core;
using NUnit.Framework;

namespace BornToCodeTests.UnitTests
{
    [TestFixture]
    public class CheckTokenTests : TokenDependent
    {
        private CheckToken sut;

        public CheckTokenTests()
        {
            sut = new CheckToken();
        }

        [Test]
        public void ShouldRecognizeTokenAsValid()
        {
            Assert.IsTrue(sut.TokenIsValid(TheGoodToken));
        }

        [Test]
        public void ShouldRecognizeTokenAsInvalid()
        {
            Assert.IsFalse(sut.TokenIsValid(TheBadToken));
            Assert.IsFalse(sut.TokenIsValid(null));
            Assert.IsFalse(sut.TokenIsValid(""));
        }
    }
}
