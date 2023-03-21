using Auth.Data.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Data.EntityFramework.Configurations
{
    internal class ItemConfig<T> : IEntityTypeConfiguration<T> where T : Item
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey( e => e.Id );
            builder.Property(e => e.Id).UseIdentityColumn();

            builder.Property( e => e.TimeStamp)
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
