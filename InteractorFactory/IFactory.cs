using InteractorAbstraction;
using PresenterAbstraction;
using Repository;

namespace InteractorFactory
{
    public interface IFactory
    {
        IAddNewCourse GetCommandNewCourse(ICourseRepository repository);
        IAddNewStudent GetCommandNewStudent(IStudentRepository studentRepository, ICourseRepository courseRepository);
        IRemoveCourse GetCommandRemoveCourse(ICourseRepository repository);
        IRemoveStudent GetCommandRemoveStudent(IStudentRepository repository);
        IUpdateCourse GetCommandUpdateCourse(ICourseRepository repository);
        IUpdateStudent GetCommandUpdateStudent(IStudentRepository studentRepository, ICourseRepository courseRepository);

        IGetAllCourse GetCommandAllCourses(ICoursesCallback presenter, ICourseRepository repository);
        IGetAllStudent GetCommandAllStudents(IStudentsCallback presenter, IStudentRepository repositiry);
        IGetCourseByID GetCommandCourseByID(ICourseCallback presenter, ICourseRepository repository);
        IGetStudentByID GetCommandStudentByID(IStudentCallback presenter, IStudentRepository repository);
    }
}
