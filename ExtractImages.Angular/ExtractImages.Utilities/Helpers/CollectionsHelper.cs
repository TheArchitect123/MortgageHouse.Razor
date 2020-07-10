using ExtractImages.SqlServer.Driver.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExtractImages.Utilities.Helpers
{
    public static class CollectionsHelper
    {
        //Filters and updates all duplicated items with new items by incrementing a value after their name
        public static List<T> UpdateAllDuplicates<T>(this IEnumerable<string> items)
        {
            throw new NotImplementedException("");
        }

        public static List<KeyValuePair<int, string>> UpdateAllDuplicatesByFileExtensions(this IEnumerable<string> fileNames, IEnumerable<int> imageIds)
        {
            List<KeyValuePair<int, string>> filteredResults = new List<KeyValuePair<int, string>>();
            var fileExtensions = fileNames.ToList().ConvertAll(i => Path.GetExtension(i));
            if (fileExtensions != null && fileExtensions.Count != 0)
            {
                //Begin processing the collection
                for (int index = 0; index <= fileNames.Count() - 1; index++)
                {
                    string withoutExtension = Path.GetFileNameWithoutExtension(fileNames.ElementAt(index));
                    if (fileNames.Count(i => i.StartsWith(withoutExtension)) != 0)
                    {
                        //Here it means that there is more than one file with this name. 

                        //Replace the file name with a new name via Guid to make it unique
                        filteredResults.Add(new KeyValuePair<int, string>(imageIds.ElementAt(index),
                            withoutExtension = $"{withoutExtension}{IntegerHelper.GenerateUniqueID()}{Path.GetExtension(fileNames.ElementAt(index))}"));
                    }
                    else //If no duplicate exists then stick to the default
                        filteredResults.Add(new KeyValuePair<int, string>(imageIds.ElementAt(index),
                            withoutExtension = $"{withoutExtension}{Path.GetExtension(fileNames.ElementAt(index))}"));
                }

                return filteredResults;
            }

            throw new ArgumentOutOfRangeException("Could not find any specified files in this thread context");
        }
    }
}
