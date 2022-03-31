using StudentAcquire.Listing.Service.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAcquire.Listing.Service.Dtos
{
    public class ListingCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price_Low { get; set; }
        public double Price_High { get; set; }
        [Required]
        public string IconImage { get; set; }
        public string CoverImage { get; set; }
        public string Website { get; set; }
        public virtual List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        [Required]
        public virtual List<SellerDto> Sellers { get; set; } = new List<SellerDto>();
    }
}
