using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceSystemERD_Models.modles
{
    public class Product
    {

        
           public  int  productId { get; set; }//int Primary Key, auto-generated, not null
           public string  productName { get; set; }//string Required, max length 150
           public string  description { get; set; }//string Optional, max length 1000
           public decimal   price { get; set; }// decimal Required, must be greater than 0
           public int  stockQuantity { get; set; }//int Required, must be greater than or equal to 0, default 0
           public string   imageUrl { get; set; }//string Optional, max length 300
           public  int  categoryId { get; set; }//int Foreign Key to Category, not null
           public DateTime createdAt { get; set; }//DateTime Required
           public  bool isAvailable { get; set; } //bool Default true










    }
}
