using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace UniversitySystemERD_Models.models
{
    public class Student
    {

       public int studentId { get; set; }//system gentarted
       public string fullName { get; set; }//user input 
        public string email { get; set; }//system gentrated
        public string phoneNumber { get; set; }//user input 
        public DateTime dateOfBirth { get; set; }//user input 
        public int enrollmentYear { get; set; }//user input 
        public decimal gpa { get; set; }//system calcluated





    }
}
