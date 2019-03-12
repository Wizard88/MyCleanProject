using System;

namespace ViewModel
{
    public class CourseSelectViewModel : BaseViewModel
    {
        public Guid ID { get; set; }
        public bool Selected { get; set; }
        public string Name { get; set; }
    }
}
