using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodServices.Models.Cascade
{
    public class MainCategory
    {
        [Key]
        public int MainCategoryId { get; set; }

        public string MainCategoryName { get; set; }

    }
}
