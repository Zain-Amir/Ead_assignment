using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Identity
{
    public class UserAddress
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        [Required]
        public int UserId { get; set; }
        public AppUser User { get; set; }
    }
}