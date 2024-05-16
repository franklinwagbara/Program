using Microsoft.EntityFrameworkCore;
using ProgramApp.Domain.Entities;

namespace ProgramApp.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<ApplicationForm> ApplicationForms { get; set; }
    public DbSet<ApplicationResponse> ApplicationResponses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationForm>().ToContainer("ApplicationForms");
        modelBuilder.Entity<ApplicationForm>().HasKey(x => x.Id);
        modelBuilder.Entity<ApplicationForm>().HasPartitionKey(x => x.Id);

        modelBuilder.Entity<ApplicationResponse>().ToContainer("ApplicationResponses");
        modelBuilder.Entity<ApplicationResponse>().HasKey(x => x.Id);
        modelBuilder.Entity<ApplicationResponse>().HasPartitionKey(x => x.Id);
    }
}
