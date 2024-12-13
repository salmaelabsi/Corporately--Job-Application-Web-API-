using JobApplicationSystem.api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace JobApplicationSystem.api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Job>(entity =>
            {
                entity.ToTable("Job");
                entity.HasKey(j => j.Id);
            });
            
            builder.Entity<Application>(x => x.HasKey(p => new { p.AppUserId, p.JobId }));

            builder.Entity<Application>()
            .HasOne(u => u.AppUser)
            .WithMany(u => u.Applications)
            .HasForeignKey(p => p.AppUserId);

            builder.Entity<Application>()
                .HasOne(u => u.Job)
                .WithMany(u => u.Applications)
                .HasForeignKey(p => p.JobId);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Application> Applications { get; set; }
    }
}