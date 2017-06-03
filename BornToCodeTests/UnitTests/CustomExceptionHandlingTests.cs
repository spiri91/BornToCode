using System;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using BornToCode.ExceptionHandling;
using BornToCode.ExceptionHandling.Exceptions;
using NUnit.Framework;

namespace BornToCodeTests.UnitTests
{
    [TestFixture]
    public class CustomExceptionHandlingTests
    {
        private CustomExceptionHandling sut;

        public CustomExceptionHandlingTests()
        {
            sut = new CustomExceptionHandling();
        }

        [Test]
        public void ShouldThrowErrors()
        {
            Assert.Throws(Is.TypeOf<HttpResponseException>(),
                () => sut.OnException(CreateContextWithException(new NotAuthorized())));
            Assert.Throws(Is.TypeOf<HttpResponseException>(),
                () => sut.OnException(CreateContextWithException(new NotFound())));
            Assert.Throws(Is.TypeOf<HttpResponseException>(),
                () => sut.OnException(CreateContextWithException(new BadFormat())));
            Assert.Throws(Is.TypeOf<HttpResponseException>(),
                () => sut.OnException(CreateContextWithException(new Exception())));
        }

        private HttpActionExecutedContext CreateContextWithException(Exception exception)
        {
            HttpActionExecutedContext context = new HttpActionExecutedContext(new HttpActionContext(), exception);

            return context;
        }
    }
}
