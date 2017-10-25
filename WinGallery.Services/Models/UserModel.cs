namespace WinGallery.Services.Models
{
    using WinGallery.DATA.Models;
    using WinGallery.Services.Mappings;

    public class UserModel : IMapFrom<User>, IMapTo<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
