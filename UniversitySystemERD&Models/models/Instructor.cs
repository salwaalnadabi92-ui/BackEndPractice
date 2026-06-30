using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UniversitySystemERD_Models.models
{
    public class Instructor
    {



        [Key]
        [Required]
        public int  instructorId {  get; set; }//system genrated 
        [Required]
        [MaxLength(100)]
        public string fullName { get; set; }//user input 
        [Required]
        [MaxLength(150)]
        public string email { get; set; }//system genrated
        [MaxLength(20)]
        public string  officeNumber { get; set; }//user input 
        [Required]
        public DateTime hireDate { get; set; }//system gentrated
        [Required]
        public decimal salary { get; set; }//user input 
        [Required]
        [MaxLength(50)]
        public  string academicTitle { get; set; }//user input 









    }
}
