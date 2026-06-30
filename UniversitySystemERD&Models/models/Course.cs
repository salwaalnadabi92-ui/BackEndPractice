using System;
using System.Collections.Generic;
using System.Text;

namespace UniversitySystemERD_Models.models
{
    public class Course
    {
       
        public int courseId {  get; set; }//user input 
        public string courseCode { get; set; }//user input 
        public string courseTitle { get; set; }//user input 
        public int creditHours { get; set; }//system calculated 
        public int departmentId { get; set; }//from the list 
        public int instructorId { get; set; }//from the list
        public string semesterOffered { get; set; }//system calculated







    }
}
