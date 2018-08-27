using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using GCCapstone6Tasklist.Domain.Models;

namespace GCCapstone6Tasklist.Data.Maps
{
    public class TaskMap : EntityTypeConfiguration<TaskToDo>
    {
        public TaskMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Description)
                .HasMaxLength(254)
                .IsRequired();
            Property(x => x.DueDate)
                .IsRequired();
            Property(x => x.IsDone)
                .IsRequired();
            HasRequired(x => x.AssignedTeamMember)
                .WithMany(tm => tm.TaskToDos)
                .HasForeignKey(tm => tm.TeamMemberId);
        }
    }
}
