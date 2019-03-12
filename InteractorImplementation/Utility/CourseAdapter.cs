using Entities;
using InteractorAbstraction.RequestModels;
using PresenterAbstraction.ResponseModel;

namespace InteractorImplementation.Utility
{
    internal class CourseAdapter
    {
        public static CourseResponse GetResponse(Course course)
        {
            return new CourseResponse()
            {
                ID = course.ID,
                Name = course.Name,
                Description = course.Description
            };
        }

        public static Course GetEntity(CourseRequest course)
        {
            return new Course()
            {
                ID = course.ID,
                Name = course.Name,
                Description = course.Description
            };
        }
    }
}
