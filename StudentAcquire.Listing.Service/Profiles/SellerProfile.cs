using AutoMapper;
using StudentAcquire.Listing.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAcquire.Listing.Service.Profiles
{
    public class SellerProfile : Profile
    {
        public SellerProfile()
        {
            CreateMap<Models.Seller, SellerDto>();
            CreateMap<SellerDto, Models.Seller>();
        }
    }
}
