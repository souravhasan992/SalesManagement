using System;

namespace Sales_Management.Data.ViewModels
{
    public class VmProductList
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public DateTime OrderDate { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
    }
}
