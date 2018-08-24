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
            var product = new TaskToDo()
            {   
                AssignedTeamMember = "Jill Palms",
                Description = "Meeting with the Bobs",
                DueDate = new DateTime(1990, 4, 20),
                IsDone = false
            };
            context.TaskToDos.Add(product);

            var customer = new TeamMember()
            {
                Name = "Jill Palms",
                Password = "BillyTheSquid"
            };
            context.TeamMembers.Add(customer);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
