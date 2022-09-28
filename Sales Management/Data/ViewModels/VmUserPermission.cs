using Sales_Management.Data.Models;
using System.Collections.Generic;

namespace Sales_Management.Data.ViewModels
{
    public class VmUserPermission
    {
        public UserLogin UserLogin { get; set; }
        public List<UserPermission> ListUserPermission { get; set; }
    }
}
