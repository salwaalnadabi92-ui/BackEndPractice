using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversitySystemERD_Models.models
{
    public class Course
    {

        [Key]
        [Required]
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
        [ForeignKey("department")]
        public int departmentId { get; set; }//from the list 
        [ForeignKey("instrutor")]
        public int instructorId { get; set; }//from the list

        [Required]
        [MaxLength(20)]
        public string semesterOffered { get; set; }//system calculated







    }
}
