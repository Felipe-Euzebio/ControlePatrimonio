using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Manager> Managers { get; set; }
        
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>()
                .HasOne(d => d.Manager)
                .WithMany()
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deletion of Manager if associated with Department

            modelBuilder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole {Name = "Admin", NormalizedName = "ADMIN"},
                    new IdentityRole {Name = "Member", NormalizedName = "MEMBER"}
                ); 
        }
    }
}