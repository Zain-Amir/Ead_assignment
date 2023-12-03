using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public string DisplayName { get; set; }
        public string Gender { get; set; }
        public DateTime Created { get; set; }
        public string ProfilPicture { get; set; }
        public UserAddress Address { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
