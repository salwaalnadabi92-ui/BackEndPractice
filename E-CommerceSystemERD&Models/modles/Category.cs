using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceSystemERD_Models.modles
{
    public  class Category
    {

                public int  categoryId { get; set; }//int Primary Key, auto-generated, not null
                public string categoryName { get; set; }//string Required, unique, max length 100
                public string description { get; set; }//string Optional, max length 500
                public string imageUrl { get; set; }//string Optional, max length 300





    }
}
