using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using BornToCode.Authorizaion;
using BornToCode.Core.Contracts;
using BornToCode.ExceptionHandling;
using BornToCodeModels;

namespace BornToCode.Controllers
{
    [CustomExceptionHandling]
    public class ArticlesController : ODataController
    {
        private IRepository<Article> articlesRepository;
        private IUnitOfWork unitOfWork;

        public ArticlesController(IRepository<Article> articlesRepository, IUnitOfWork unitOfWork)
        {
            this.articlesRepository = articlesRepository;
            this.unitOfWork = unitOfWork;
        }

        [EnableQuery]
        public IQueryable<Article> Get() => articlesRepository.Query().ToList().AsQueryable();

        [EnableQuery]
        public SingleResult<Article> Get([FromODataUri] Guid key)
        {
            var article = articlesRepository.Query().Where(x => x.Id == key).ToList();

            return SingleResult.Create(article.AsQueryable());
        }

        [CustomAuthorize]
        public async Task<IHttpActionResult> Post(Article article)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            articlesRepository.Add(article);

            SaveChanges();

            return Created(article);
        }

        [CustomAuthorize]
        public async Task<IHttpActionResult> Put([FromODataUri] Guid key, Article update)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (key != update.Id)
                return BadRequest();

            articlesRepository.Put(update);

            SaveChanges();

            return Updated(update);
        }

        [CustomAuthorize]
        public async Task<IHttpActionResult> Delete([FromODataUri] Guid key)
        {
            var entityToDelete = articlesRepository.Query().SingleOrDefault(x => x.Id == key);
            if (entityToDelete == null)
                return NotFound();

            articlesRepository.Delete(entityToDelete);
            SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        private void SaveChanges() => unitOfWork.SaveState(articlesRepository);
    }
}