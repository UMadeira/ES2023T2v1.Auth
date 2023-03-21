using Auth.Data.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Data.EntityFramework.Configurations
{
    internal class GroupConfig : ItemConfig<Group>
    {
        public override void Configure(EntityTypeBuilder<Group> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(e => e.Parent)
                .WithMany(e => e.Children)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(e => e.Users)
                .WithMany(e => e.Groups);
        }
    }
}
