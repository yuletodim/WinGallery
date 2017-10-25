namespace WinGallery.Web.Models
{
    using WinGallery.Services.Mappings;
    using WinGallery.Services.Models;

    public class PictureViewModel : IMapFrom<PictureModel>, IMapTo<PictureModel>
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }

        public int ContestID { get; set; }

        public string ContestName { get; set; }

        public int Votes { get; set; }
    }
}