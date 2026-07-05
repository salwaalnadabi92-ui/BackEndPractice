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
            public  int  productId { get; set; }
            [Required]
            [MaxLength(150)]
            public string  productName { get; set; }
            [MaxLength(1000)]
            public string ? description { get; set; }
            [Required]
            [Range(1,decimal.MaxValue)]
            public decimal   price { get; set; }
            [Required]
            [Range(0, int.MaxValue)]
            public int  stockQuantity { get; set; }=0
            [MaxLength(300)]
            public string ?  imageUrl { get; set; }
            [Required]
            [ForeignKey("")]
            public  int  categoryId { get; set; }
            [Required]
            public DateTime createdAt { get; set; }
            public  bool isAvailable { get; set; }= true











    }
}
