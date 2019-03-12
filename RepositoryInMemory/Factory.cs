using Repository;
using RepositoryFactory;

namespace RepositoryImplementation
{
    public class Factory : IFactory
    {
        public ICourseRepository GetCourseRepository()
        {
            return new CourseRepository();
        }

        public IStudentRepository GetStudentRepository()
        {
            return new StudentRepository();
        }
    }
}
