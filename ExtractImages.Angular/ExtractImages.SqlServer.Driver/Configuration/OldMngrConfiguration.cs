using ExtractImages.SqlServer.Driver.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortgageHouse.Backend.SqlServerDriver.Configurations
{
    public class OldMngrConfiguration : IEntityTypeConfiguration<Old>
    {
        public void Configure(EntityTypeBuilder<Old> builder)
        {
            builder.ToTable(nameof(Old));
        }
    }
}
