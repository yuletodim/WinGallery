namespace WinGallery.Services.Interfaces
{
    using System.Collections.Generic;
    using Models;
    using System.Threading.Tasks;

    public interface IContestsServices
    {
        IEnumerable<ContestModel> GetAll();

        Task<ContestModel> GetById(int id);
    }
}
