using System.Data.Entity.Migrations;
using BornToCode.DataBaseFunctions;

namespace BornToCode.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BornToCodeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BornToCodeContext context)
        {
            DbActions dbActions;
#if DEBUG
            dbActions = new DebugTestDataSeed(context);
#else
            dbActions = new ReleaseSeed(context);
#endif

            dbActions.Seed();
        }
    }
}
