using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversitySystemERD_Models.models
{
    [Index(nameof(departmentName), IsUnique = true)]

    public class Department
    {

        [Key]
        [Required]
        public int departmentId {  get; set; }// system genrtated

        [Required]
        [MaxLength(100)]
        public string departmentName {  get; set; }//user input 

        [MaxLength(20)]
        public string building { get; set; }//user input 
        [Required]
        public decimal budget { get; set; }//user input 

        [ForeignKey("Instructor")]
        public int headInstructorId { get; set; }//user input 




    }
}
