using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;

namespace BornToCode.ExceptionHandling
{
    class CustomExceptionHandling : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            CheckExceptionMessage(context.Exception.Message);
        }

        public override Task OnExceptionAsync(HttpActionExecutedContext context, CancellationToken cancellationToken)
        {
            CheckExceptionMessage(context.Exception.Message);

            return Task.FromResult<object>(null);
        }

        private void CheckExceptionMessage(string message)
        {
            switch (message)
            {
                case "NotAuthorized":
                    throw new HttpResponseException(HttpStatusCode.Unauthorized);

                case "ObjectNotFound":
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                default:
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}
