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
        public int TeamMemberId { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "DueDate")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? DueDate { get; set; }

        [Required]
        public bool IsDone { get; set; }

        //public TeamMember AssignedTeamMember { get; set; }

    }
}