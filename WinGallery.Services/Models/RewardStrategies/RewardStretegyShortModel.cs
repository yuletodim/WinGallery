namespace WinGallery.Services.Models.RewardStrategies
{
    using WinGallery.DATA.Models;
    using WinGallery.Services.Mappings;

    public class RewardStretegyShortModel : IMapFrom<RewardStrategy>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
