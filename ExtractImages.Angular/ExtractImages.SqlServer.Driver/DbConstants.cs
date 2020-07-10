namespace ExtractImages.SqlServer.Driver
{
    public struct DbConstants
    {
        public const string ImageDirectory = "C:\\ExtractedImages\\";
        public const string DbConnectionString = "Server=.\\SQLExpress;Database=mortgageHouseDb;Trusted_Connection=True;Integrated Security=true;MultipleActiveResultSets=true";
        public const string DbConnectionSchema = "dbo";
    }
}
