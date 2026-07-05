using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceSystemERD_Models.modles
{
    public class Review
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int reviewId {  get; set; }

        [Required]
        [ForeignKey("")]
        public int userId {  get; set; }

        [Required]
        [ForeignKey("")]
        public int  productId {  get; set; }
        [Required]
        [Range(1, 5)]
        public   int  rating {  get; set; }
        [MaxLength(1000)]
        public   string ? comment {  get; set; }
        [Required]
        public   DateTime  reviewDate {  get; set; }

    }
}
