using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace UniversitySystemERD_Models.models
{
    public class Student
    {

       public int studentId { get; set; }
       public string fullName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int enrollmentYear { get; set; }
        public decimal gpa { get; set; }





    }
}
