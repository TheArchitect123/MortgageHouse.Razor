using System;

namespace ExtractImages.SqlServer.Driver.Helpers
{
    public class IntegerHelper
    {
        public static Guid GenerateUniqueID() => Guid.NewGuid();
    }
}
