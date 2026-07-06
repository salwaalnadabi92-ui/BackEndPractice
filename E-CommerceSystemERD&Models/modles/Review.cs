using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace E_CommerceSystemERD_Models.modles
{
    public class Review
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int reviewId {  get; set; }//system genrated

        [Required]
        [ForeignKey("user")]
        public int userId {  get; set; }//foreign key //from list
        public User user { get; set; } // navigation property(user:review)



        [Required]
        [ForeignKey("product")]
        public int  productId {  get; set; }//foreign key //from list
        public Product product { get; set; }  // navigation property(product: review)


        [Required]
        [Range(1, 5)]
        public   int  rating {  get; set; }//user input 
        [MaxLength(1000)]
        public   string ? comment {  get; set; }//user input 
        [Required]
        public   DateTime  reviewDate {  get; set; }//system genrated

    }
}
