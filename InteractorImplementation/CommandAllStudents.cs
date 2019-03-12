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
    internal class CommandAllStudents : IGetAllStudent
    {
        private readonly IStudentsCallback _presenter;
        private readonly IStudentRepository _repository;

        public CommandAllStudents(IStudentsCallback presenter, IStudentRepository repository)
        {
            _presenter = presenter;
            _repository = repository;
        }

        public void Execute()
        {
            List<Student> students = _repository.GetAll();
            List<StudentResponse> response = students.Select(x => StudentAdapter.GetResponse(x)).ToList();
            _presenter.Notify(response);
        }
    }
}