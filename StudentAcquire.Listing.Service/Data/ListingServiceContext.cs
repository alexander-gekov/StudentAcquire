using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentAcquire.Listing.Service.Models;

namespace StudentAcquire.Listing.Service.Data
{
    public class ListingServiceContext : DbContext
    {
        public ListingServiceContext (DbContextOptions<ListingServiceContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Listing> Listing { get; set; }
    }
}
