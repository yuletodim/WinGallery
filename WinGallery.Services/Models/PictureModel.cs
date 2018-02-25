namespace WinGallery.Services.Models
{
    using AutoMapper;
    using WinGallery.DATA.Models;
    using WinGallery.Services.Mappings;

    public class PictureModel : IMapFrom<Picture>, IMapTo<Picture>, IHaveCustomMappings
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }

        public int ContestID { get; set; }

        public  string ContestName { get; set; }

        public int? Votes { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Picture, PictureModel>()
                .ForMember(x => x.ContestName, opt => opt.MapFrom(x => x.Contest.Title));
        }
    }
}
