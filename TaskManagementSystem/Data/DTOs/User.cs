using System.ComponentModel.DataAnnotations;
using TaskManagementSystem.Data.Enums;

namespace TaskManagementSystem.Data.DTOs
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public bool Trashed { get; set; }
        public EnumUserRoles UserRole { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}
