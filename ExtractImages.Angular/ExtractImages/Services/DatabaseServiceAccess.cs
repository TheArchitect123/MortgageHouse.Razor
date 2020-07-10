﻿using AutoMapper;
using ExtractImages.SqlServer.Driver;
using ExtractImages.SqlServer.Driver.Entities;
using ExtractImages.SqlServer.Driver.Repositories;
using System.IO;
using System.Linq;
using System.Security.Policy;

namespace ExtractImages.Services
{
    public class DatabaseServiceAccess
    {
        private readonly NewDataRepository _newDataRepository;
        private readonly OldDataRepository _oldDataRepository;
        private readonly IMapper _mapper;

        public DatabaseServiceAccess(IMapper mapper, NewDataRepository newDataRepository, OldDataRepository oldDataRepository)
        {
            _newDataRepository = newDataRepository;
            _oldDataRepository = oldDataRepository;
            _mapper = mapper;
        }

        private New GetNewItemFromDto(Old item, ref New newItem)
        {
            //Write the file into the directory from the byte stream
            string filePath = Path.Combine(DbConstants.ImageDirectory, item.filename);
            File.WriteAllBytes(filePath, item.image);
            newItem.imagePath = filePath;

            return newItem;
        }

        public void ClearAllData()
        {
            if (!(_newDataRepository.RemoveAllNewItems() && _newDataRepository.SaveChanges()))
                throw new InvalidDataException($"Failed to clear all the items from the \'new\' table on the database \'{DbConstants.DbConnectionSchema}\'");

            //Remove all files from the ImageDirectory
            Directory.Delete(DbConstants.ImageDirectory); //Drop the directory so you don't have to iterate through the records
            Directory.CreateDirectory(DbConstants.ImageDirectory);
        }

        /// <summary>
        /// Run all data from the 'old' table to the 'new' table
        /// </summary>
        public void InitializeDataMigrationToNew()
        {
            if (!(_newDataRepository.AddNewItems(_oldDataRepository.GetOldItems().ToList().ConvertAll(w =>
            {
                var item = _mapper.Map<Old, New>(w);
                return GetNewItemFromDto(w, ref item);
            })) && _newDataRepository.SaveChanges()))
                throw new InvalidDataException($"Failed to clear all the items from the \'new\' table on the database \'{DbConstants.DbConnectionSchema}\'");
        }
    }
}
