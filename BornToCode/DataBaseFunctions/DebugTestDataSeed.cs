using System;
using System.Linq;
using BornToCodeModels;

namespace BornToCode.DataBaseFunctions
{
    public class DebugTestDataSeed : DbActions
    {
        public DebugTestDataSeed(BornToCodeContext context) : base(context)
        {
        }

        public override void Seed()
        {
            Enumerable.Range(1, 50).ToList().ForEach(x =>
            {
                context.Articles.Add(new Article(Guid.NewGuid(), "title" + x, "content" + x));
            });
        }

        public override void DeleteAll()
            => context.Database.SqlQuery<string>("DELETE FROM Articles");
    }
}