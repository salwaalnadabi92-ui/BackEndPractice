using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversitySystemERD_Models.models
{
    public class Instructor
    {



        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [Range(1, double.MaxValue)]
        public decimal salary { get; set; }//user input 
        [Required]
        [MaxLength(50)]
        public  string academicTitle { get; set; }//user input 


        [ForeignKey("course")]
        public int courseId { get; set; }// Foreign key property
        public course Course {  get; set; }//Navigation property(course: instrutor)






    }
}
