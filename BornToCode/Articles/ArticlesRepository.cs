using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using BornToCode.Core.Contracts;
using BornToCodeModels;

namespace BornToCode.Articles
{
    public class ArticlesRepository : IRepository<Article>
    {
        private BornToCodeContext context;

        public ArticlesRepository() : this(new BornToCodeContext()) { }

        public ArticlesRepository(BornToCodeContext context) { this.context = context; }

        public void Put(Article entity) => context.Set<Article>().AddOrUpdate(entity);
       
        public void Add(Article entity) => context.Articles.Add(entity);

        public void Delete(Article entity) => context.Articles.Remove(entity);

        public List<Article> FetchAll() => context.Articles.ToList();

        public IQueryable<Article> Query() => context.Articles;

        public void Save() => context.SaveChanges();
        
        ~ArticlesRepository() { context.Dispose(); }
    }
}