namespace WinGallery.Services.Interfaces
{
    using System.Collections.Generic;
    using DATA.Models;
    using Models;

    public interface IContestsServices
    {
        IEnumerable<ContestModel> GetAll();

        ContestModel GetById(int id);
    }
}
