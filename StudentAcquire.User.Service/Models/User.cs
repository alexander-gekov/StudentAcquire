using StudentAcquire.User.Service.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAcquire.User.Service.Models
{
    [Table("Listings")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public List<Listing> Listings { get; set; }

    }
}
