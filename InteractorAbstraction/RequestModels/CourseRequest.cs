using System;

namespace InteractorAbstraction.RequestModels
{
    public class CourseRequest
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}