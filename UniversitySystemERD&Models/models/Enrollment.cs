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

        [ForeignKey("course")]
        public int courseId { get; set; }//Foreign key property 
        public Course course { get; set; } // Navigation property(course : enrollment)


    }
}
