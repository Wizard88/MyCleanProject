using System;

namespace InteractorImplementation
{
    public class StudentException : Exception
    {
        public StudentException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
