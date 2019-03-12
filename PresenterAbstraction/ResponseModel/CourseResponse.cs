using System;

namespace PresenterAbstraction.ResponseModel
{
    public class CourseResponse
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}