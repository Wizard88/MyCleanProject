using Entities;
using System;
using System.Collections.Generic;

namespace Repository
{
    public interface ICourseRepository
    {
        void AddNew(Course course);
        void Update(Course course);

        List<Course> GetAll();
        Course GetByID(Guid id);
        void Remove(Guid id);
    }
}
