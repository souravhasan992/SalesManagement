using System.ComponentModel.DataAnnotations;

namespace Sales_Management.Data.Models
{
    public class UserPermission
    {
        [Key]
        public int PermissionId { get; set; }
        public int MenuIid { get; set; }
        public bool? IsRead { get; set; }
        public bool? IsCreate { get; set; }
        public bool? IsUpdate { get; set; }
        public bool? IsDelete { get; set; }
        public int? UserId { get; set; }
    }
}
