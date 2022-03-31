using AutoMapper;
using StudentAcquire.Listing.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAcquire.Listing.Service.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Models.Category, CategoryDto>();
            CreateMap<CategoryDto, Models.Category>();
        }
    }
}
