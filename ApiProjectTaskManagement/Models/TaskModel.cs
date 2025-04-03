using System.ComponentModel.DataAnnotations;

namespace ApiProjectTaskManagement.Models
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}
