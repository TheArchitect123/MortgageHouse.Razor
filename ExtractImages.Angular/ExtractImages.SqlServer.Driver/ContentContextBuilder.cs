using ExtractImages.SqlServer.Driver;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MortgageHouse.Backend.SqlServerDriver
{
    public class ContentContextBuilder : IDesignTimeDbContextFactory<ContentDb>
    {
        public ContentDb CreateDbContext(string[] args)
        {
            //Configure Sql Server as the Provider
            var builder = new DbContextOptionsBuilder<ContentDb>()
                   .UseSqlServer(DbConstants.DbConnectionString);

            return new ContentDb(builder.Options);
        }
    }
}
