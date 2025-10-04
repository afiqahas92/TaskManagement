using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Application.DTOs
{
    public class CreateTaskDto
    {
        [Required(ErrorMessage = "Task title is required")]
        [StringLength(200, ErrorMessage = "Task title cannot exceed 200 characters")]
        public string Title { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string Description { get; set; } = string.Empty;
    }
}
