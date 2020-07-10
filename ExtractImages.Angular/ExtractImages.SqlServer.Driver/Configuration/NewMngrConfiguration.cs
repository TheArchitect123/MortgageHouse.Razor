using ExtractImages.SqlServer.Driver.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MortgageHouse.Backend.SqlServerDriver.Configurations
{
    public class NewMngrConfiguration : IEntityTypeConfiguration<New>
    {
        public void Configure(EntityTypeBuilder<New> builder)
        {
            builder.ToTable(nameof(New));
        }
    }
}
