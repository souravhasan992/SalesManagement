using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales_Management.Data.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

    }
}
