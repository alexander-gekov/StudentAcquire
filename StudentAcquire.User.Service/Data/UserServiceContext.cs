using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentAcquire.User.Service.Models;

namespace StudentAcquire.User.Service.Data
{
    public class UserServiceContext : DbContext
    {
        public UserServiceContext (DbContextOptions<UserServiceContext> options)
            : base(options)
        {
        }

        public DbSet<Models.User> Users { get; set; }
    }
}
