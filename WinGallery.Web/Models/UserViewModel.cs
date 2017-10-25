namespace WinGallery.Web.Models
{
    using WinGallery.Services.Mappings;
    using WinGallery.Services.Models;

    public class UserViewModel : IMapFrom<UserModel>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}