using Entities;
using InteractorAbstraction;
using InteractorAbstraction.RequestModels;
using InteractorImplementation.Utility;
using Repository;
using System;

namespace InteractorImplementation
{
    internal class CommandNewCourse : IAddNewCourse
    {
        private readonly ICourseRepository _repository;

        public CommandNewCourse(ICourseRepository repository)
        {
            _repository = repository;
        }

        public void Execute(CourseRequest course)
        {
            Course entity = CourseAdapter.GetEntity(course);

            try
            {
                _repository.AddNew(entity);
            }
            catch (Exception exc)
            {
                throw new StudentException("Eror while create new course!", exc);
            }
        }
    }
}