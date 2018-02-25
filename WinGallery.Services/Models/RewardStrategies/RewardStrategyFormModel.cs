namespace WinGallery.Services.Models.RewardStrategies
{
    using System.ComponentModel.DataAnnotations;
    using WinGallery.DATA.Common;
    using WinGallery.DATA.Models;
    using WinGallery.Services.Mappings;

    public class RewardStrategyFormModel : IMapTo<RewardStrategy>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int NumberOfPrizes { get; set; }

        public string UserId { get; set; }
    }
}
