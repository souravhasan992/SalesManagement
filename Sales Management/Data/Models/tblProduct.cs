using System.ComponentModel.DataAnnotations;
using System;
using Sales_Management.Common;

namespace Sales_Management.Data.Models
{
    public class tblProduct
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "This Field is required.")]
        [ExcludeCharacter("@!?")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "This Field is required.")]
        public string Price { get; set; }
        [Required(ErrorMessage = "This Field is required.")]
        [custom]
        public DateTime OrderDate { get; set; }

        public string ImageName { get; set; }

        public string ImageUrl { get; set; }
    }
}
