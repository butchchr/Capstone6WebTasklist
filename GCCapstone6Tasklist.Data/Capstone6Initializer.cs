using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GCCapstone6Tasklist.Domain.Models;

namespace GCCapstone6Tasklist.Data
{
    public class Capstone6Initializer : DropCreateDatabaseAlways<Capstone6Context>
    {
        protected override void Seed(Capstone6Context context)
        {
            var teamMember = new TeamMember()
            {
                Name = "Jill Palms",
                Email = "JillPalms@michigan.org",
                Password = "BillyTheSquid"
            };
            context.TeamMembers.Add(teamMember);

            var taskToDo = new TaskToDo()
            {
                AssignedTeamMember = teamMember,
                Description = "Meeting with the Bobs",
                DueDate = new DateTime(1990, 4, 20),
                IsDone = false
            };
            context.TaskToDos.Add(taskToDo);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
