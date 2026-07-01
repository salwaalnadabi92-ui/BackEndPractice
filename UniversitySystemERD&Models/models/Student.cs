using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int studentId { get; set; }//system gentarted

        [Required]
        [MaxLength(100)]
        public string fullName { get; set; }//user input 

        [Required]
        [MaxLength(150)]
        public string email { get; set; }//system gentrated

        [MaxLength(20)]
        public string ?phoneNumber { get; set; }//user input 

        [Required]
        public DateTime dateOfBirth { get; set; }//user input 

        [Required]
        [Range(2000 , 2030)]
        public int enrollmentYear { get; set; }//user input 

        [Range(0.0 ,4.0)]
                                                                                                                                                                                                                     
        public decimal gpa { get; set; } = 0.0m;//system calcluated


        public List<enrollment> enrollment{ get; set; } // Navigation property (student :enrollment)

        public List<course> course { get; set; } // Navigation property (student : course)



    }
}
