using System;
using System.Collections.Generic;
using System.Text;

namespace UniversitySystemERD_Models.models
{
    public class Course
    {
       
        public int courseId {  get; set; }
        public string courseCode { get; set; }
        public string courseTitle { get; set; }
        public int creditHours { get; set; }
        public int departmentId { get; set; }
        public int instructorId { get; set; }
        public string semesterOffered { get; set; }







    }
}
