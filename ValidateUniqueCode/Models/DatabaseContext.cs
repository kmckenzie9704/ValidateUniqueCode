using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ValidateUniqueCode.Models
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext()  { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options) {
            string strNull = string.Empty;
        }

        public DbSet<UniqueCode> UniqueCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UniqueCode.OnModelCreating(modelBuilder);

        }
    }
}