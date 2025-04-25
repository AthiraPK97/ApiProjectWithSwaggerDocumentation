using System.ComponentModel.DataAnnotations;

namespace ApiProjectTaskManagement.Models
{
    public class TaskModel
    {
       
           [Key]
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
        public string IsCompleted { get; set; }

    }
    }

