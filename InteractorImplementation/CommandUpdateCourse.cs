using Entities;
using InteractorAbstraction;
using InteractorAbstraction.RequestModels;
using InteractorImplementation.Utility;
using Repository;
using System;

namespace InteractorImplementation
{
    internal class CommandUpdateCourse : IUpdateCourse
    {
        private readonly ICourseRepository _repository;

        public CommandUpdateCourse(ICourseRepository repository)
        {
            _repository = repository;
        }

        public void Execute(CourseRequest course)
        {
            try
            {
                Course entity = CourseAdapter.GetEntity(course);
                _repository.Update(entity);
            }
            catch (Exception exc)
            {
                throw new CourseException("Error while update course!", exc);
            }
        }
    }
}