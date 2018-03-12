using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ValidateUniqueCode.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
            { }

        public DbSet<UniqueCode> UniqueCodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=tcp:applicants.database.windows.net,1433;Initial Catalog=Applicants;Persist Security Info=False;User ID=kmckenzie;Password=2qaw#WSE;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            optionsBuilder.UseSqlServer("Server=tcp:applicants.database.windows.net,1433;Initial Catalog=Applicants;Persist Security Info=False;User ID=kenneth.mckenzie@myacuity.com;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Authentication=Active Directory Integrated;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UniqueCode.OnModelCreating(modelBuilder);

        }
    }
}