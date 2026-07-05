using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceSystemERD_Models.modles
{
    public  class Order
    {
        [key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderId { get; set; }
        [Required]
        [ForeignKey("")]
        public int  userId { get; set; }
        [Required]
        public DateTime orderDate { get; set; }
        [Required]
        [Range(0,double.MaxValue)]
        public decimal totalAmount { get; set; } // must be greater than or equal to 0
        [Required]
        [MaxLength(30)]
        public string   status { get; set; }= "Pending" 
        [Required]
        [MaxLength(300)]
        public string  shippingAddress { get; set; }
        [Required]
        [MaxLength(50)]
        public string  paymentMethod { get; set; }





    }
}
