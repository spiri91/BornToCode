using System;

namespace BornToCode.ExceptionHandling.Exceptions
{
    public class BadFormat : Exception
    {
        public BadFormat() : base(ErrorType.BadFormat.ToString()) { }
    }
}