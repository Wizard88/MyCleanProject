using Entities;
using System;
using System.Collections.Generic;

namespace RepositoryImplementation
{
    internal class InMemoryRepository
    {
        private static InMemoryRepository _instance;

        public static InMemoryRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InMemoryRepository();
                }

                return _instance;
            }
        }

        public List<Student> ListStudent { get; set; }
        public List<Course> ListCourses { get; set; }

        public InMemoryRepository()
        {
            ListStudent = new List<Student>();
            ListCourses = new List<Course>
            {
                new Course() {ID=Guid.NewGuid(), Name = "My course 1", Description = "Description course 1" },
                new Course() {ID=Guid.NewGuid(), Name = "My course 2", Description = "Description course 2" },
                new Course() {ID=Guid.NewGuid(), Name = "My course 3", Description = "Description course 3" }
            };
        }
    }
}
