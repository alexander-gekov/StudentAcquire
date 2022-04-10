using StudentAcquire.Listing.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAcquire.Listing.Service.Dtos
{
    public class ListingReadDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price_Low { get; set; }
        public double Price_High { get; set; }
        public string IconImage { get; set; }
        public string CoverImage { get; set; }
        public int Views { get; set; }
        public int MessagesSent { get; set; }
        public string Website { get; set; }
        public virtual List<Category> Categories { get; set; } = new List<Category>();
        public SellerDto Seller { get; set; }
        public bool Sold { get; set; }
    }
}
