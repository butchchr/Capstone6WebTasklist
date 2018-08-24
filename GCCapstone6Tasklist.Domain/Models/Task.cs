using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCCapstone6Tasklist.Domain.Models
{
    public class Task
    {
        public int Id { get; set; }

        public string AssignedTeamMember { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsDone { get; set; }
    }
}
