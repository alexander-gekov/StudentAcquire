using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentAcquire.Listing.Service.Models;

namespace StudentAcquire.Listing.Service.Data
{
    public class StudentAcquireListingServiceContext : DbContext
    {
        public StudentAcquireListingServiceContext (DbContextOptions<StudentAcquireListingServiceContext> options)
            : base(options)
        {
        }

        public DbSet<StudentAcquire.Listing.Service.Models.Listing> Listing { get; set; }
    }
}
