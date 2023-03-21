using Auth.Data.Classes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
