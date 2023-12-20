using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Data.DTOs
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        public bool Trashed { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public int TaskStatus { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public int? AssignedTo { get; set; }
    }
}
