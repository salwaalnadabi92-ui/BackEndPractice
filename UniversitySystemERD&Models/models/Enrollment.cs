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
        public int studentId { get; set; }//from list 
        public Student student { get; set; }

        [ForeignKey("course")]
        public int courseId { get; set; }//from list 
        public Course course { get; set; }
        [Required]
        public DateTime  enrollmentDate { get; set; }//system genrated
        [MaxLength(2)]
        public string ?  finalGrade { get; set; }//system calculated
        [Required]
        [MaxLength(20)]
        public string status { get; set; } = "in progress";//user input 

        [ForeignKey("student")]
        public int studentId { get; set; }// Foreign key property 
        public Student  student { get; set; } // Navigation property




    }
}
