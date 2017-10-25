namespace WinGallery.Services.Interfaces
{
    using System.Collections.Generic;
    using WinGallery.Services.Models;

    public interface IUsersServices
    {
        IEnumerable<UserModel> GetAll();

        UserModel GetById(string id);
    }
}
