using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceSystemERD_Models.modles
{
    public  class Order
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderId { get; set; }//system genrated 



        [Required]
        [ForeignKey("user")]
        public int  userId { get; set; }//
        public User user { get; set; } // navigation property(user :order)



        [Required]
        public DateTime orderDate { get; set; }//system gentrated


        [Required]
        [Range(0,double.MaxValue)]
        public decimal totalAmount { get; set; } // system calculated 


        [Required]
        [MaxLength(30)]
        public string status { get; set; } = "Pending";// default value


        [Required]
        [MaxLength(300)]
        public string  shippingAddress { get; set; }//user input 



        [Required]
        [MaxLength(50)]
        public string  paymentMethod { get; set; }//  from list — "CreditCard" | "DebitCard" | "PayPal" | "Cash"



        public List<orderItem> OrderItems { get; set; } = new List<orderItem>();



    }
}
