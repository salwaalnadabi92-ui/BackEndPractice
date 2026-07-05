using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceSystemERD_Models.modles
{
    public  class Category
    {
                      [Key]
                      [Required]
                      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                      public int  categoryId { get; set; }//system genrated 
                      [Required]
                      [MaxLength(100)]
                      public string categoryName { get; set; }// uniqu user input 
                      [MaxLength(500)]
                      public string? description { get; set; }//user input
                      [MaxLength(300)]
                      public string? imageUrl { get; set; }//user input 





    }
}
