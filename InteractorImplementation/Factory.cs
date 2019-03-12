using InteractorAbstraction;
using InteractorFactory;
using PresenterAbstraction;
using Repository;

namespace InteractorImplementation
{
    public class Factory : IFactory
    {
        public IGetAllCourse GetCommandAllCourses(ICoursesCallback presenter, ICourseRepository repository)
        {
            return new CommandAllCourses(presenter, repository);
        }

        public IGetAllStudent GetCommandAllStudents(IStudentsCallback presenter, IStudentRepository repository)
        {
            return new CommandAllStudents(presenter, repository);
        }

        public IGetCourseByID GetCommandCourseByID(ICourseCallback presenter, ICourseRepository repository)
        {
            return new CommandCourseByID(presenter, repository);
        }

        public IAddNewCourse GetCommandNewCourse(ICourseRepository repository)
        {
            return new CommandNewCourse(repository);
        }

        public IAddNewStudent GetCommandNewStudent(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            return new CommandNewStudent(studentRepository, courseRepository);
        }

        public IRemoveCourse GetCommandRemoveCourse(ICourseRepository repository)
        {
            return new CommandRemoveCourse(repository);
        }

        public IRemoveStudent GetCommandRemoveStudent(IStudentRepository repository)
        {
            return new CommandRemoveStudent(repository);
        }

        public IGetStudentByID GetCommandStudentByID(IStudentCallback presenter, IStudentRepository repository)
        {
            return new CommandStudentByID(presenter, repository);
        }

        public IUpdateCourse GetCommandUpdateCourse(ICourseRepository repository)
        {
            return new CommandUpdateCourse(repository);
        }

        public IUpdateStudent GetCommandUpdateStudent(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            return new CommandUpdateStudent(studentRepository, courseRepository);
        }
    }
}
