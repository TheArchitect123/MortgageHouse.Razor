using System;
using System.IO;

namespace ExtractImages.Constants
{
    public struct DbConstants
    {
        public static string ConnectionString = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "MortgageHouse\\MortgageHouseDb.db3");
        public static string ConnectionStringDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "MortgageHouse");

        public const string MngrSchema = "MortgageHouseSchema";
    }
}
