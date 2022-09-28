using System.ComponentModel.DataAnnotations;

namespace Sales_Management.Data.Models
{
    public class UserLogin
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public int? UserType { get; set; }
    }
}
