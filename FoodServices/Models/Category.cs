using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace FoodServices.Models
{
    [Table(name:"Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]

        [Display(Name = "Food Category")]
        public string CategoryName { get; set; }

        public ICollection<MenuItem> MenuItem { get; set; }
    }
}
