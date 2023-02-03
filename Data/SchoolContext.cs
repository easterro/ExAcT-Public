using ExtracurricularActivitiyLog.Models;
using Microsoft.EntityFrameworkCore;

namespace ExtracurricularActivitiyLog.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<Roster> Rosters { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>().ToTable("Clubs");
            modelBuilder.Entity<Roster>().ToTable("Rosters");
            modelBuilder.Entity<Student>().ToTable("Students");
        }
    }
}