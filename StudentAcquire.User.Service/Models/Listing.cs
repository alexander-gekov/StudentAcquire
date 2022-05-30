using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAcquire.User.Service.Models
{
    public class Listing
    {
        public Listing(int id, int externalId, string name, string description)
        {
            Id = id;
            ExternalId = externalId;
            Name = name;
            Description = description;
        }
        [Key]
        public int Id { get; set; }
        public int ExternalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
