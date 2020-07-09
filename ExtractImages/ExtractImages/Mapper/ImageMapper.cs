using AutoMapper;
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
            InitializeToDto();
            InitializeFromDto();
        }

        public void InitializeToDto()
        {
            //this.CreateMap<Address, AddressDto>();
        }

        public void InitializeFromDto()
        {
            //this.CreateMap<AddressDto, Address>();
        }
    }
}
