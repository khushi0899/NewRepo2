using FoodServices.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodServices.Areas.Restaurant.ViewModels
{
    public class ShowCategories
    {
        [Required(ErrorMessage = "{0} cannot be empty")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }


        public ICollection<MenuItem> MenuItems { get; set; }

    }
}
