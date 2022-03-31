using AutoMapper;
using StudentAcquire.Listing.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAcquire.Listing.Service.Profiles
{
    public class ListingsProfile : Profile
    {
        public ListingsProfile()
        {
            CreateMap<Models.Listing, ListingReadDto>();
            CreateMap<ListingCreateDto, Models.Listing>();
        }
    }
}
