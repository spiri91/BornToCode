using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BornToCode.Core.Contracts;
using BornToCode.ExceptionHandling.Exceptions;
using BornToCodeModels;

namespace BornToCode.Articles
{
    public class ArticlesRepository : IRepository<Article>
    {
        private BornToCodeContext context;

        public ArticlesRepository() : this(new BornToCodeContext()) { }

        public ArticlesRepository(BornToCodeContext context)
        {
            this.context = context;
        }

        public void Put(Article entity)
        {
            CheckIfExists(entity.Id);
            context.Entry(entity).State = EntityState.Modified;
        }

       
        public void Add(Article entity)
        {
            context.Articles.Add(entity);
        }

        public void Delete(Article entity)
        {
            context.Articles.Remove(entity);
        }

        public List<Article> FetchAll()
        {
            return context.Articles.ToList();
        }

        public IQueryable<Article> Query()
        {
            return context.Articles;
        }

        public async void Save()
        {
            await context.SaveChangesAsync();
        }

        private void CheckIfExists(Guid id)
        {
            var entity = context.Articles.SingleOrDefault(x => x.Id == id);

            if(entity == null)
                throw new NotFound();
        }

        ~ArticlesRepository()
        {
            context.Dispose();
        }
    }
}