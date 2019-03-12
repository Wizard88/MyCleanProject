using Entities;
using InteractorAbstraction;
using InteractorAbstraction.RequestModels;
using InteractorImplementation.Utility;
using Repository;
using System;
using System.Linq;

namespace InteractorImplementation
{
    internal class CommandUpdateStudent : IUpdateStudent
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public CommandUpdateStudent(IStudentRepository repository, ICourseRepository courseRepository)
        {
            _studentRepository = repository;
            _courseRepository = courseRepository;
        }

        public void Execute(StudentRequest student)
        {
            try
            {
                Student entity = StudentAdapter.GetEntity(student);
                entity.ListCources = student.ListCourses.Select(x => _courseRepository.GetByID(x)).ToList();

                _studentRepository.Update(entity);
            }
            catch (Exception exc)
            {
                throw new StudentException("Error while update student!", exc);
            }
        }
    }
}