using AutoMapper;
using ExtractImages.SqlServer.Driver.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtractImages.Mapper
{
    public class ImageMapper : Profile
    {
        public ImageMapper()
        {
            InitializeFromOld();
            InitializeToNew();
        }

        public void InitializeToNew()
        {
            this.CreateMap<Old, New>();
        }

        public void InitializeFromOld()
        {
            this.CreateMap<New, Old>();
        }
    }
}
