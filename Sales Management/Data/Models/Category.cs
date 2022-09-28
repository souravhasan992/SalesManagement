using System.ComponentModel.DataAnnotations;

namespace Sales_Management.Data.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
