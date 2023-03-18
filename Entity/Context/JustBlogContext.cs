using Entity.Config;
using Entity.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entity.Context
{
    public class JustBlogContext : IdentityDbContext<User, Role, Guid>
    {
        public JustBlogContext(DbContextOptions<JustBlogContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfig).Assembly);

            modelBuilder.Seed();
            modelBuilder.Entity<IdentityUserLogin<Guid>>()
                .ToTable("UserLogin")
                .HasKey(x => new { x.UserId, x.ProviderKey });
            modelBuilder.Entity<IdentityUserRole<Guid>>()
                .ToTable("UserRole")
                .HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserToken<Guid>>()
                .ToTable("UserToken")
                .HasKey(x => new { x.UserId, x.LoginProvider });

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                    entityType.SetTableName(tableName.Substring(6));
            }
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTagMap> PostTagMaps { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}