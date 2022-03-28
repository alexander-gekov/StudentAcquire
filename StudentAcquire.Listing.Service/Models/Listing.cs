
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAcquire.Listing.Service.Models
{
    [Table("Listings")]
    public class Listing
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public virtual List<Seller> Sellers { get; set; } = new List<Seller>();
        public bool Sold { get; set; }
    }
}
