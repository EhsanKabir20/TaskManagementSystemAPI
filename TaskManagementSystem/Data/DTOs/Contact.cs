using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace TaskManagementSystem.Data.DTOs
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public bool Trashed { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
    }
}
