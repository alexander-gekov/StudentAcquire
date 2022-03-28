
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAcquire.Listing.Service.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string ImageURL { get; set; }
    }
}
