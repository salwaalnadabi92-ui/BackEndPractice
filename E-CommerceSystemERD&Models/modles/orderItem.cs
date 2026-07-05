using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceSystemERD_Models.modles
{
    public  class orderItem

    {
        [Required]
        [Range(1,999)]
        public int quantity { get; set; }
      


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderItemId { get; set; }  // system generated


        [Required]
        [ForeignKey("order")]
        public int orderId { get; set; } // foreign key //from list       
         public Order order {  get; set; }// navigation property 


        [Required]
        [ForeignKey("Product")]
        public int productId { get; set; } // foreign key //from list
        public Product product { get; set; }// navigation property 









    }
}
