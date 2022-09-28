using Sales_Management.Data.Models;
using System.Collections.Generic;

namespace Sales_Management.Data.ViewModels
{
    public class VmProductCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<VmProduct> ProductList { get; set; }
    }
}
