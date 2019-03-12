using Entities;
using InteractorAbstraction.RequestModels;
using PresenterAbstraction.ResponseModel;
using System;
using System.Linq;

namespace InteractorImplementation.Utility
{
    internal class StudentAdapter
    {
        public static StudentResponse GetResponse(Student item)
        {
            return new StudentResponse()
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                Age = item.Age,
                Sex = GetSexInt(item.Sex),
                ListCourses = item.ListCources.Select(x => x.ID).ToList()
            };
        }


        public static Student GetEntity(StudentRequest item)
        {
            return new Student()
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                Age = item.Age,
                Sex = GetEnum(item.Sex)
            };
        }

        private static Sex GetEnum(int sex)
        {
            switch (sex)
            {
                case 1: return Sex.Male;
                case 2: return Sex.Female;
                default: throw new InvalidCastException();
            }
        }

        private static int GetSexInt(Sex sex)
        {
            switch (sex)
            {
                case Sex.Male: return 1;
                case Sex.Female: return 2;
                default: throw new InvalidCastException();
            }
        }
    }
}
