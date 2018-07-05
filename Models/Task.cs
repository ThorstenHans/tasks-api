using System;
using System.ComponentModel.DataAnnotations;

namespace Tasks.API.Models
{
    public class Task
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }
        [Timestamp]
        public DateTime CreatedAt { get; set; }
    }
}
