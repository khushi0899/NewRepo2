using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodServices.Models.Cascade
{
    public class MainItems
    {
        [Key]
        public int MainItemsId { get; set; } 

        public int MainItemsName { get; set; } 

        public MainCategory MainCategory { get; set; }  


    }
}
