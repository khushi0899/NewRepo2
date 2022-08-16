using FoodServices.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FoodServices.Areas.MenuList.ViewModels
{
    public class ShowMenuViewModel
    {
        [Required(ErrorMessage = "{0} cannot be empty")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }


        public ICollection<MenuItem> MenuItems { get; set; }

        public int? Quantity { get; set; }
    }
}
