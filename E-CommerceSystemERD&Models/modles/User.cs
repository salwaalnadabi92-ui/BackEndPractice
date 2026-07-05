using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
namespace E_CommerceSystemERD_Models.modles
{
    [Index(nameof(username),nameof(email), IsUnique = true)]
    
    public class User
            {
           [Required]
           [Key]
           [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public    int  userId { get; set; }

           [Required]
           [MaxLength(50)]
          
            public  string  username { get; set; }

           [Required]
           [MaxLength(150)]

           public  string email { get; set; }

           [Required]
           [MaxLength(256)]
            public  string passwordHash { get; set; }

           [Required]
           [MaxLength(100)]
           public  string fullName { get; set; }


            [MaxLength(20)]
            public  string? phoneNumber { get; set; }
            [MaxLength(30)]
            public  string ?address { get; set; }
            [Required]
            public DateTime registrationDate { get; set; }


           public bool isActive { get; set; } = true;


    }
}
