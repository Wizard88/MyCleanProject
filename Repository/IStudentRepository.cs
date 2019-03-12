using Entities;
using System;
using System.Collections.Generic;

namespace Repository
{
    public interface IStudentRepository
    {
        void AddNew(Student student);
        void Update(Student student);

        List<Student> GetAll();
        Student GetByID(Guid id);
        void Remove(Guid id);
    }
}
