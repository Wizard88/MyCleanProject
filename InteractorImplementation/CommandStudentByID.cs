using Entities;
using InteractorAbstraction;
using InteractorImplementation.Utility;
using PresenterAbstraction;
using PresenterAbstraction.ResponseModel;
using Repository;
using System;

namespace InteractorImplementation
{
    internal class CommandStudentByID : IGetStudentByID
    {
        private readonly IStudentCallback _presenter;
        private readonly IStudentRepository _repository;

        public CommandStudentByID(IStudentCallback presenter, IStudentRepository repository)
        {
            _presenter = presenter;
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            try
            {
                Student entity = _repository.GetByID(id);
                StudentResponse response = StudentAdapter.GetResponse(entity);
                _presenter.Notify(response);
            }
            catch (Exception exc)
            {
                throw new StudentException("Error while get student!", exc);
            }
        }
    }
}