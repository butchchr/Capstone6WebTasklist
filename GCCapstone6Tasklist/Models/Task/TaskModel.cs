using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GCCapstone6Tasklist.Models.Tasks
{
    public class TaskModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Team Member ID")]
        public int TeamMemberId { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Due Date")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? DueDate { get; set; }

        [Required]
        [Display(Name = "Task Complete")]
        public bool IsDone { get; set; }
    }
}