using System;

namespace InteractorAbstraction
{
    public class StudentException : Exception
    {
        public StudentException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class CourseException : Exception
    {
        public CourseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
