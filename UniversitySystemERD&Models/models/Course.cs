using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversitySystemERD_Models.models
{
    [Index(nameof(courseCode), IsUnique = true)]

    public class Course
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int courseId {  get; set; }//user input 

        [Required]
        [MaxLength(10)]
        public string courseCode { get; set; }//user input 
        [Required]
        [MaxLength(150)]
        public string courseTitle { get; set; }//user input 
        [Required]
        [Range(1, 6)]
        public int creditHours { get; set; }//system calculated 
      
        [Required]
        [MaxLength(20)]
        public string semesterOffered { get; set; }//system calculated


        [ForeignKey("student")]
        public int studentId { get; set; }// Foreign key property
        public List<student> student { get; set; } // Navigation property (student :course)


        public List<enrollment> enrollment { get; set; } // Navigation property (course:enrollment)


        [ForeignKey("instrutor")]
        public int instructorId { get; set; }// Foreign key property
        public Instructor instrutor { get; set; } // Navigation property (course:instrutor)


        [ ForeignKey("department")]
        public int departmentId { get; set; }//Foreign key property 
        public Department department { get; set; }//Navigation property (department: course)


    }
}
