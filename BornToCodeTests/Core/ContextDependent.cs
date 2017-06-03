using BornToCode;
using BornToCode.DataBaseFunctions;
using NUnit.Framework;

namespace BornToCodeTests.Core
{
    public abstract class ContextDependent
    {
        protected BornToCodeContext Context;
        private DebugTestDataSeed Dbts;

        protected ContextDependent()
        {
            Context = new BornToCodeContext();
            Dbts = new DebugTestDataSeed(Context);
        }

        [SetUp]
        protected void BeforeEachTest()
        {
            Dbts.DeleteAll();
            Dbts.Seed();
        }

        [TearDown]
        protected void AfterEachTest()
        {
            Dbts.DeleteAll();
        }

        ~ContextDependent()
        {
            Context.Dispose();
        }
    }
}
