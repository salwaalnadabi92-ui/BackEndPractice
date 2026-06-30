using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversitySystemERD_Models.models
{
    public class Enrollment

    {


        [Key]
        [Required]
        public int enrollmentId {  get; set; }//system genrtated
        [ForeignKey("student")]
        public int    studentId { get; set; }//from list 
        [ForeignKey("course")]
        public int courseId { get; set; }//from list 
        [Required]
        public DateTime  enrollmentDate { get; set; }//system genrated
        [MaxLength(2)]
        public string    finalGrade { get; set; }//system calculated
        [Required]
        [MaxLength(20)]
        public string  status { get; set; }//user input 


    }
}
