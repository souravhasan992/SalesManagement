using Sales_Management.Data.Models;
using System.Collections.Generic;

namespace Sales_Management.Data.ViewModels
{
    public class VmCategoryWiseProduct
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<VmCategory> CategoryList { get; set; }
        public List<VmProduct> ProductList { get; set; }
    }
}
