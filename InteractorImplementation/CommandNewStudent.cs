using Entities;
using InteractorAbstraction;
using InteractorAbstraction.RequestModels;
using InteractorImplementation.Utility;
using Repository;
using System;
using System.Linq;

namespace InteractorImplementation
{
    internal class CommandNewStudent : IAddNewStudent
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public CommandNewStudent(IStudentRepository repository, ICourseRepository courseRepository)
        {
            _studentRepository = repository;
            _courseRepository = courseRepository;
        }

        public void Execute(StudentRequest student)
        {
            Student entity = StudentAdapter.GetEntity(student);
            entity.ListCources = student.ListCourses.Select(x => _courseRepository.GetByID(x)).ToList();

            try
            {
                _studentRepository.AddNew(entity);
            }
            catch (Exception exc)
            {
                throw new StudentException("Error while create student!", exc);
            }
        }
    }
}