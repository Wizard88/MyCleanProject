using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryImplementation
{
    internal class StudentRepository : IStudentRepository
    {
        public void AddNew(Student student)
        {
            InMemoryRepository.Instance.ListStudent.Add(student);
        }

        public List<Student> GetAll()
        {
            return InMemoryRepository.Instance.ListStudent;
        }

        public Student GetByID(Guid id)
        {
            return InMemoryRepository.Instance.ListStudent.First(x => x.ID == id);
        }

        public void Remove(Guid id)
        {
            Student itemForRemove = InMemoryRepository.Instance.ListStudent.First(x => x.ID == id);
            InMemoryRepository.Instance.ListStudent.Remove(itemForRemove);
        }

        public void Update(Student student)
        {
            Student itemForUpdate = InMemoryRepository.Instance.ListStudent.First(x => x.ID == student.ID);

            itemForUpdate.FirstName = student.FirstName;
            itemForUpdate.LastName = student.LastName;
            itemForUpdate.Sex = student.Sex;
            itemForUpdate.Age = student.Age;
            itemForUpdate.ListCources = student.ListCources;
        }
    }
}
