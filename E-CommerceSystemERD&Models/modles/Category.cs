using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Xml.Linq;

namespace E_CommerceSystemERD_Models.modles
{

    [Index(nameof(categoryName), IsUnique = true)]

    public class Category
    {
                      [Key]
                      [Required]
                      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                      public int  categoryId { get; set; }//system genrated 


                      [Required]
                      [MaxLength(100)]
                      //[Index(IsUnique = true)]
                      public string categoryName { get; set; }//user input 

                      [MaxLength(500)]
                      public string? description { get; set; }//user input

                      [MaxLength(300)]
                      public string? imageUrl { get; set; }//user input 


                      public List<Product> Products { get; set; }//navigation   — ( Category : Products)


    }
}
