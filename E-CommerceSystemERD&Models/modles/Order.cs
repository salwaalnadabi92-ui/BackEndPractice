using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceSystemERD_Models.modles
{
    public  class Order
    {

        public int orderId { get; set; }// int Primary Key, auto-generated, not null
        public int  userId { get; set; }//int Foreign Key to User, not null
        public DateTime orderDate { get; set; } //DateTime Required
        public decimal totalAmount { get; set; } //decimal Required, must be greater than or equal to 0
        public string   status { get; set; }//string Required, max length 30, default "Pending"
        public string  shippingAddress { get; set; }//string Required, max length 300
         public string  paymentMethod { get; set; }//string Required, max length 50





    }
}
