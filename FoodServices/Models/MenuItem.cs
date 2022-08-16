using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel;
using System;
namespace FoodServices.Models
{
    [Table(name:"MenuItem")]
    public class MenuItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        virtual public int ItemId { get; set; }

        [Display(Name = "Dish Name")]
        virtual public string ItemName { get; set; }

        [Required]
        [Column(TypeName = "decimal")]
        [Display(Name = " Dish Price")]
        virtual public decimal ItemPrice { get; set; }


        [Display(Name = "Dish Image URL")]
        [StringLength(500)]
        public virtual string ImageUrl { get; set; } = null;

        [Display(Name ="Dish Category")]
        public virtual int CategoryId { get; set; }      //foregine key constraint

        [ForeignKey(nameof(MenuItem.CategoryId))]
        public Category Category { get; set; }

        public ICollection<OrderAnyItem> OrderAnyItem { get; set; }
    }
}
