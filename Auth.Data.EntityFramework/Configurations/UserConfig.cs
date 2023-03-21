using Auth.Data.Classes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Data.EntityFramework.Configurations
{
    internal class UserConfig : ItemConfig<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder
                .HasMany( e => e.Groups )
                .WithMany( e  => e.Users );
        }
    }
}
