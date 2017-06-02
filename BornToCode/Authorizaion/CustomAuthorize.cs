using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
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

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token = GetAuthorizationHeader(actionContext);
            Check(token);
        }

        public override Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var token = GetAuthorizationHeader(actionContext);
            Check(token);

            return Task.FromResult<object>(null);
        }

        private string GetAuthorizationHeader(HttpActionContext context)
        {
            var value = context.Request.Headers.Authorization.Scheme;
            return value;
        }

        private void Check(string token)
        {
            if (autorize.TokenIsValid(token))
                return;

            throw new NotAuthorized();
        }
    }
}