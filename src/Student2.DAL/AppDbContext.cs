using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Student2.BL.Entities;
using Student2.DAL.Configuration;

namespace Student2.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>, AppUserRole,
        IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DbSet<University> Universities { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<Course> Course { get; set; } = null!;
        public DbSet<Tutor> Tutor { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;

        public AppDbContext() { }
        public AppDbContext(DbContextOptions opts) : base(opts) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UseSnakeCase();
            modelBuilder.ApplyConfiguration(new AppRolesConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        }
    }
}