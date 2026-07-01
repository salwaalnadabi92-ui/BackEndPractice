using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceSystemERD_Models.modles
{
    public class User
    {

           public    int  userId { get; set; }                                    //Primary Key, auto-generated, not null
           public  string  username { get; set; }                                    //string// Required, unique, max length 50
           public  string email { get; set; }                                   //Required, unique, max length 150
           public  string passwordHash { get; set; }                              //string Required, max length 256
           public  string fullName { get; set; }                                    //string Required, max length 100
           public  string phoneNumber { get; set; }                                     //string Optional, max length 20
           public  string address { get; set; }                                       //string Optional, max length 30

           public DateTime registrationDate { get; set; }//Required
           public  bool    isActive { get; set; }//Default true


    }
}
