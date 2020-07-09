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
            this.CreateMap<Address, AddressDto>();
            this.CreateMap<Contact, ContactDto>();
            this.CreateMap<ContactAddress, ContactAddressDto>();
        }

        public void InitializeFromDto()
        {
            this.CreateMap<AddressDto, Address>();
            this.CreateMap<ContactDto, Contact>();
            this.CreateMap<ContactAddressDto, ContactAddress>();
        }
    }
}
