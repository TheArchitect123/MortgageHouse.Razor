using ExtractImages.SqlServer.Driver;
using ExtractImages.SqlServer.Driver.Entities;
using Microsoft.EntityFrameworkCore;
using MortgageHouse.Backend.SqlServerDriver.Configurations;

namespace MortgageHouse.Backend.SqlServerDriver
{
    public class ContentDb : DbContext
    {
        public ContentDb(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DbConstants.DbConnectionSchema);

            //Configurations
            modelBuilder.ApplyConfiguration(new OldMngrConfiguration());
            modelBuilder.ApplyConfiguration(new NewMngrConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        //Data
        public DbSet<Old> sOldItems { get; set; }
        public DbSet<New> sNewitems { get; set; }
    }
}
