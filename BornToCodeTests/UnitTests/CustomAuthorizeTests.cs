using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Routing;
using BornToCode.Authorizaion;
using BornToCodeTests.Core;
using NUnit.Framework;

namespace BornToCodeTests.UnitTests
{
    [TestFixture]
    public class CustomAuthorizeTests : TokenDependent
    {
        private CustomAuthorize sut;
       
        public CustomAuthorizeTests()
        {
            sut = new CustomAuthorize();
        }

        [Test]
        public void ShouldPassAuthorization()
        {
            sut.OnAuthorization(BuildContext(TheGoodToken));
        }

        [Test]
        public void ShouldNotPassAuthorization()
        {
            Assert.Throws(Is.InstanceOf<Exception>(), () => sut.OnAuthorization(BuildContext(TheBadToken)));
        }

        [Test]
        public void ShouldPassAuthorizationAsync()
        {
            sut.OnAuthorizationAsync(BuildContext(TheGoodToken), CancellationToken.None);
        }

        [Test]
        public void ShouldNotPassAuthorizationAsync()
        {
            Assert.Throws(Is.InstanceOf<Exception>(),
                () => sut.OnAuthorizationAsync(BuildContext(TheBadToken), CancellationToken.None));
        }

        private HttpActionContext BuildContext(string token)
        {
            var controllerContext = new HttpControllerContext(new HttpConfiguration(),
                new HttpRouteData(new HttpRoute()), new HttpRequestMessage()
                {
                    Headers = {Authorization = new AuthenticationHeaderValue(token)}
                });

            return new HttpActionContext(controllerContext, new ReflectedHttpActionDescriptor());
        }
    }
}
