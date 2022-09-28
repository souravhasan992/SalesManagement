using Microsoft.AspNetCore.Http;
using Sales_Management.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Sales_Management.Data.ViewModels
{
    public class VmProductCreate
    {
        [Key]
        public int ProductId { get; set; }
        [DisplayName("Product Name")]
        [Required(ErrorMessage = "This Field is required.")]
        [ExcludeCharacter("@!?")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "This Field is required.")]
        public string Price { get; set; }
        [DisplayName("Order Date")]
        [Required(ErrorMessage = "This Field is required.")]
        [custom]
        public System.DateTime OrderDate { get; set; }
        [DisplayName("Image Name")]
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
