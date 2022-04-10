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
            CreateMap<Models.Listing, ListingReadDto>().ForMember(d=> d.Seller, o => o.MapFrom(s=> s.Seller));
            CreateMap<ListingCreateDto, Models.Listing>();
        }
    }
}
