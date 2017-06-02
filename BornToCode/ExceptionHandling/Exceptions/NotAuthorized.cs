using System;

namespace BornToCode.ExceptionHandling.Exceptions
{
    public class NotAuthorized : Exception
    {
        public NotAuthorized() : base(ErrorType.NotAuthorized.ToString()) { }

    }
}