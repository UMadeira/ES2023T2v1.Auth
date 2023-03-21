using Auth.Data.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Auth.Data.EntityFramework
{
    public class AuthContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);

            builder
                .UseLazyLoadingProxies()
                .UseSqlServer(
                    @"data source=(LocalDb)\MSSQLLocalDB;" +
                    @"initial catalog=Auth2023T2v1;" +
                    @"integrated security=True; " +
                    @"MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new GroupConfig());
            modelBuilder.ApplyConfiguration(new PermissionConfig());
        }
    }
}