using System.Linq;
using BornToCode;
using BornToCode.DataBaseFunctions;
using NUnit.Framework;

namespace BornToCodeTests.UnitTests
{
    
    [TestFixture]
    public class DebugTestDataSeedTests
    {
        private DebugTestDataSeed DataSeed;
        private BornToCodeContext context;

        public DebugTestDataSeedTests()
        {
            context = new BornToCodeContext();
            DataSeed = new DebugTestDataSeed(context);
        }

        [Test]
        public void ShouldSeedDatabaseTableArticles()
        {
            SeedAndSave();

            Assert.IsTrue(context.Articles.ToList().Count > 0);
        }

        [Test]
        public void ShouldTruncateDatabaseTableArticles()
        {
            SeedAndSave();

            DataSeed.DeleteAll();
            Assert.IsTrue(context.Articles.ToList().Count == 0);
        }

        private void SeedAndSave()
        {
            DataSeed.Seed();
            context.SaveChanges();
        }

        ~DebugTestDataSeedTests()
        {
            context.Dispose();
        }
    }
}
