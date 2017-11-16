using System;
using System.Collections.Generic;
using System.Text;

namespace ManyToManyRelation
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<StudentCourse> Courses { get; set; } = new List<StudentCourse>();
    }
}
