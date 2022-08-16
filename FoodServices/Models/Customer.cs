using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel;
using System;
namespace FoodServices.Models
{
    [Table(name: "Customer")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        virtual public int CustomerId { get; set; }


        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Column(TypeName = "varchar(100)")]
        [StringLength(100)]
        [Display(Name = "Name")]
        virtual public string CustomerName { get; set; }


        [StringLength(100)]
        [Display(Name = "Customer Card")]
        virtual public string YourCard { get; set; }


        [Required(ErrorMessage = "{0} cannot be empty!")]
        [StringLength(200)]
        [Display(Name = "Address")]
        virtual public string Address { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [StringLength(10)]
        [Display(Name = "phone")]
        virtual public string CustomerPhone { get; set; }


        [Required(ErrorMessage = "{0} cannot be empty!")]
        [StringLength(50)]
        [Display(Name = "City")]
        virtual public string AddressCity { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [StringLength(50)]
        [Display(Name = "Email")]
        virtual public string Email { get; set; }


        [Display(Name = "Add You Image")]
        [StringLength(500)]
        public virtual string ImageUrl { get; set; } = null;

        [Display(Name = "Customer Card")]

        public static int Cardno = 0;
        static string DefaultValue = "JASH_0";
        static string GenerateId()
        {
            string Card = DefaultValue + (++Cardno);
            return Card;
         
        }
        public string CustomerCard
        {
            get
            {
                return YourCard;
            }
            set
            {
                YourCard = GenerateId();
            }
        }

        public ICollection<OrderAnyItem> OrderAnyItem { get; set; }

    }
}
