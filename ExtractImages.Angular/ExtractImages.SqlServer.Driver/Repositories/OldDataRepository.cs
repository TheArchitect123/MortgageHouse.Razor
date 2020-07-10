using ExtractImages.SqlServer.Driver.Entities;
using MortgageHouse.Backend.SqlServerDriver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtractImages.SqlServer.Driver.Repositories
{
    public class OldDataRepository
    {
        public OldDataRepository(ContentDb contentMngr)
        {
            _contentMngr = contentMngr;
        }

        public ContentDb _contentMngr;
        public IEnumerable<Old> GetOldItems()
        {
            try
            {
                return _contentMngr.sOldItems.ToList();
            }
            catch (Exception ex)
            {
                //Add some logging here...
                throw ex;
            }
        }
    }
}
