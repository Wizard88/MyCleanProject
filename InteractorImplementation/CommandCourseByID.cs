using Entities;
using InteractorAbstraction;
using InteractorImplementation.Utility;
using PresenterAbstraction;
using PresenterAbstraction.ResponseModel;
using Repository;
using System;

namespace InteractorImplementation
{
    internal class CommandCourseByID : IGetCourseByID
    {
        private readonly ICourseCallback _presenter;
        private readonly ICourseRepository _repository;

        public CommandCourseByID(ICourseCallback presenter, ICourseRepository repository)
        {
            _presenter = presenter;
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            Course entity = _repository.GetByID(id);
            CourseResponse response = CourseAdapter.GetResponse(entity);
            _presenter.Notify(response);
        }
    }
}