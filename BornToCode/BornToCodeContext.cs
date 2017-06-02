using System.Data.Entity;
using BornToCodeModels;

namespace BornToCode
{
    public class BornToCodeContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }  


    }
}