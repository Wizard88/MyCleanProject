using InteractorAbstraction;
using Repository;
using System;

namespace InteractorImplementation
{
    internal class CommandRemoveCourse : IRemoveCourse
    {
        private readonly ICourseRepository _repository;

        public CommandRemoveCourse(ICourseRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            try
            {
                _repository.Remove(id);
            }
            catch (Exception exc)
            {
                throw new CourseException("Error while remove course!", exc);
            }
        }
    }
}