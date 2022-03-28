
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAcquire.Listing.Service.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryText { get; set; }
    }
}
