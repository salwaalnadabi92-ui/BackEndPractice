using System;
using System.Collections.Generic;
using System.Text;

namespace UniversitySystemERD_Models.models
{
    public class Enrollment

    {
       public int enrollmentId {  get; set; }//system genrtated
       public int    studentId { get; set; }//from list 
       public int courseId { get; set; }//from list 
       public DateTime  enrollmentDate { get; set; }//system genrated
       public string    finalGrade { get; set; }//system calculated
       public string  status { get; set; }//user input 


    }
}
