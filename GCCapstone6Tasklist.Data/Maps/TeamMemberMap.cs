﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using GCCapstone6Tasklist.Domain.Models;

namespace GCCapstone6Tasklist.Data.Maps
{
    public class TeamMemberMap : EntityTypeConfiguration<TeamMember>
    {
        public TeamMemberMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
            Property(x => x.Email)
                .HasMaxLength(254)
                .IsRequired();
            Property(x => x.Password)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
