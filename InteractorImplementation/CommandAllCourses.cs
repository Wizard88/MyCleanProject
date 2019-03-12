using Entities;
using InteractorAbstraction;
using InteractorImplementation.Utility;
using PresenterAbstraction;
using PresenterAbstraction.ResponseModel;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace InteractorImplementation
{
    internal class CommandAllCourses : IGetAllCourse
    {
        private readonly ICoursesCallback _presenter;
        private readonly ICourseRepository _repository;

        public CommandAllCourses(ICoursesCallback presenter, ICourseRepository repository)
        {
            _presenter = presenter;
            _repository = repository;
        }

        public void Execute()
        {
            List<Course> courses = _repository.GetAll();
            List<CourseResponse> response = courses.Select(x => CourseAdapter.GetResponse(x)).ToList();
            _presenter.Notify(response);
        }
    }
}