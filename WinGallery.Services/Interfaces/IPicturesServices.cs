namespace WinGallery.Services.Interfaces
{
    using System.Linq;
    using DATA.Models;

    public interface IPictuiresService
    {
        IQueryable<Picture> GetAll();

        Picture GetById();
    }
}
