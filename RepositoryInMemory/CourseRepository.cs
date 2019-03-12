using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryImplementation
{
    internal class CourseRepository : ICourseRepository
    {
        public void AddNew(Course course)
        {
            InMemoryRepository.Instance.ListCourses.Add(course);
        }

        public List<Course> GetAll()
        {
            return InMemoryRepository.Instance.ListCourses;
        }

        public Course GetByID(Guid id)
        {
            return InMemoryRepository.Instance.ListCourses.First(x => x.ID == id);
        }

        public void Remove(Guid id)
        {
            Course itemForRemove = InMemoryRepository.Instance.ListCourses.First(x => x.ID == id);
            InMemoryRepository.Instance.ListCourses.Remove(itemForRemove);
        }

        public void Update(Course course)
        {
            Course itemForUpdate = InMemoryRepository.Instance.ListCourses.First(x => x.ID == course.ID);

            itemForUpdate.Name = course.Name;
            itemForUpdate.Description = course.Description;
        }
    }
}
