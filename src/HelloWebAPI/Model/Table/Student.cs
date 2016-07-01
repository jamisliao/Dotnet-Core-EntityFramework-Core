using System;
using System.Collections.Generic;

namespace HelloWebAPI.Model.Table
{
    public partial class Student
    {
        public Guid StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentGender { get; set; }
        public DateTime StudentCreateDateTime { get; set; }
    }
}
