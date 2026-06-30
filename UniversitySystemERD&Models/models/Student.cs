using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;
using System.Xml.Linq;

namespace UniversitySystemERD_Models.models
{
    [Index(nameof(email), IsUnique = true)]
    public class Student
    {

        [Key]
        [Required]
        public int studentId { get; set; }//system gentarted

        [Required]
        [MaxLength(100)]
        public string fullName { get; set; }//user input 

        [Required]
        [MaxLength(150)]
        public string email { get; set; }//system gentrated

        [MaxLength(20)]
        public string phoneNumber { get; set; }//user input 

        [Required]
        public DateTime dateOfBirth { get; set; }//user input 

        [Required]
        [Range(2000 , 2030)]
        public int enrollmentYear { get; set; }//user input 

        [Range(0.0 ,4.0)]
                                                                                                                                                                                                                     
        public decimal gpa { get; set; }//system calcluated





    }
}
