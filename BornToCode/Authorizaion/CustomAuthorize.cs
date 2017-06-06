using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using BornToCode.Core;
using BornToCode.Core.Contracts;
using BornToCode.ExceptionHandling.Exceptions;

namespace BornToCode.Authorizaion
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        private IAutorize autorize;

        public CustomAuthorize() : this(new CheckToken()) { }

        public CustomAuthorize(IAutorize autorize)
        {
            this.autorize = autorize;
        }

        public override void OnAuthorization(HttpActionContext actionContext) =>
            Check(GetAuthorizationHeader(actionContext));

        public override Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            Check(GetAuthorizationHeader(actionContext));

            return Task.FromResult<object>(null);
        }

        private string GetAuthorizationHeader(HttpActionContext context)
        {
            if (context.Request.Headers.Authorization == null)
                throw new NotAuthorized();

            return context.Request.Headers.Authorization.Scheme;
        }

        private void Check(string token)
        {
            if (autorize.TokenIsValid(token))
                return;

            throw new NotAuthorized();
        }
    }
}