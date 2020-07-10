using ExtractImages.SqlServer.Driver.Entities;
using ExtractImages.Utilities.Helpers;
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

        private New GenerateItemForNewTb(New prevItem, string newFileName)
        {
            New item = prevItem;
            item.filename = newFileName;

            return item;
        }

        public IEnumerable<New> AddNewItems(IEnumerable<New> items)
        {
            try
            {
                //Filter and remove duplicates by updating their file names, then pass this to the parent context for processing
                var newElements = items.ToList();
                var updatedFileNames = items.Select(w => w.filename).UpdateAllDuplicatesByFileExtensions(items.Select(w => w.image_id)); //Get the updated file names
                foreach (var newItem in items.ToList())
                    newElements[newElements.IndexOf(newItem)] = GenerateItemForNewTb(newItem, updatedFileNames.FirstOrDefault(w => w.Key == newItem.image_id).Value);

                _contentMngr.AddRange(newElements); //Persist the new items
                return newElements;
            }
            catch (Exception ex)
            {
                //Add some logging here...
                throw ex;
            }
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
