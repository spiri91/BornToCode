using System;

namespace BornToCode.ExceptionHandling.Exceptions
{
    public class NotFound : Exception
    {
        public NotFound() : base(ErrorType.ObjectNotFound.ToString()) { }
    }
}