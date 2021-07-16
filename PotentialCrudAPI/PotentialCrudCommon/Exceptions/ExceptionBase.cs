using System;

namespace PotentialCrudCommon.Exceptions
{
    public class ExceptionBase : Exception
    {
        public ExceptionBase(string message) : base(message) { }
    }
}
