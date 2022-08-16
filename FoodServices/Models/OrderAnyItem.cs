using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace FoodServices.Models
{
    [Table(name: "OrderAnyItem")]
    public class OrderAnyItem
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        virtual public int OrderAnyItemId { get; set; }


        [Required]
        [DefaultValue(0)]
        [Display(Name = "Food Quantity")]
        virtual public int FoodQuantity { get; set; }


        [Display(Name = "Choose Menu Item")]
        public virtual int MenuId { get; set; }      //foregine key constraint

        [ForeignKey(nameof(OrderAnyItem.MenuId))]
        public MenuItem MenuItem { get; set; }


        [Display(Name = "Choose Your Card ")]
        public virtual int CustomerId { get; set; }      //foregine key constraint

        [ForeignKey(nameof(OrderAnyItem.CustomerId))]
        public Customer Customer { get; set; }




    }
}
