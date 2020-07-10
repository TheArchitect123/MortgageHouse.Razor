using ExtractImages.SqlServer.Driver.Entities;
using MortgageHouse.Backend.SqlServerDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtractImages.SqlServer.Driver.Repositories
{
    public class NewDataRepository
    {
        public NewDataRepository(ContentDb contentMngr)
        {
            _contentMngr = contentMngr;
        }

        public ContentDb _contentMngr;

        public IEnumerable<New> AddNewItems(IEnumerable<New> items)
        {
            try
            {
                //Filter and remove duplicates by updating their file names, then pass this to the parent context for processing
                items.GroupBy(w=> w.filename).Select(w => w.)
                _contentMngr.AddRange(items);
            }
            catch (Exception ex)
            {
                //Add some logging here...
                throw ex;
            }

            return null;
        }

        public bool RemoveAllNewItems()
        {
            try
            {
                _contentMngr.RemoveRange(_contentMngr.sNewitems.ToList()); //Removes all the items
            }
            catch (Exception ex)
            {
                //Add some logging here...
                throw ex;
            }

            return true;
        }

        public IEnumerable<New> GetNewItems()
        {
            try
            {
                return _contentMngr.sNewitems.ToList();
            }
            catch (Exception ex)
            {
                //Add some logging here...
                throw ex;
            }
        }

        public bool SaveChanges()
        {
            try { _contentMngr.SaveChanges(); }
            catch { return false; }

            return true;
        }
    }
}
