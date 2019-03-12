﻿using System;
using System.Collections.Generic;

namespace PresenterAbstraction.ResponseModel
{
    public class StudentResponse
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Sex { get; set; }

        public List<Guid> ListCourses { get; set; }
    }
}