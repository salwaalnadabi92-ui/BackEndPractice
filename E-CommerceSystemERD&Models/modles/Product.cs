using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceSystemERD_Models.modles
{
    public class Product
    {

            [Key]
            [Required]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public  int  productId { get; set; }//system gentrated

            [Required]
            [MaxLength(150)]
            public string  productName { get; set; }//user input 

            [MaxLength(1000)]
            public string ? description { get; set; }//user input 

              [Column(TypeName = "decimal(10,2)")]
              [Range(0.01, double.MaxValue)]
              public decimal price { get; set; }//user input 

             [Required]
            [Range(0, double.MaxValue)]
            public int stockQuantity { get; set; } = 0;//defualt value
            [MaxLength(300)]
            public string ?  imageUrl { get; set; }//user input 

            [Required]
            [ForeignKey("category")]
            public  int  categoryId { get; set; }//Foreign Key //from list 
            public Category category { get; set; }// navigation property( category: product)
          
             [Required]
             public DateTime createdAt { get; set; }//system genrated
            public bool isAvailable { get; set; } = true;//defulat value





     
        public List<Review> Reviews { get; set; } = new List<Review>();   //  navigation — ( Product : Reviews)

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();//
        // reverse navigation — one Product appears in many OrderItems (bridge table)





    }
}
