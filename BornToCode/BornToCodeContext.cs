using System.Data.Entity;
using BornToCodeModels;

namespace BornToCode
{
    public class BornToCodeContext : DbContext
    {
        public BornToCodeContext() : base("BornToCode")
        {
            
        }

        public DbSet<Article> Articles { get; set; }  
    }
}