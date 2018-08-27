using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCCapstone6Tasklist.Data.Maps;
using GCCapstone6Tasklist.Domain.Models;


namespace GCCapstone6Tasklist.Data
{
    public class Capstone6Context : DbContext
    {
        public Capstone6Context() : base()
        {
            Database.SetInitializer(new Capstone6Initializer());
        }

        public IDbSet<TaskToDo> TaskToDos { get; set; } 
        public IDbSet<TeamMember> TeamMembers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TaskMap());
            modelBuilder.Configurations.Add(new TeamMemberMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
