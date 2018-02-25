namespace WinGallery.Web.Models.RewardStrategies
{
    using System.ComponentModel.DataAnnotations;
    using WinGallery.DATA.Common;
    using WinGallery.Services.Mappings;
    using WinGallery.Services.Models.RewardStrategies;

    public class RewardStrategyBindingModel : IMapTo<RewardStrategyFormModel>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.RewardStrategyNameMinLength, ErrorMessage = DataConstants.RewardStrategyNameErrorMessage)]
        [MaxLength(DataConstants.RewardStrategyNameMaxLength, ErrorMessage = DataConstants.RewardStrategyNameErrorMessage)]
        [Display(Name = "Name", ResourceType = typeof(Resources.Texts))]
        public string Name { get; set; }

        [MaxLength(DataConstants.RewardStrategyNameMaxLength, ErrorMessage = DataConstants.RewardStrategyNameErrorMessage)]
        [Display(Name = "Description", ResourceType = typeof(Resources.Texts))]
        public string Description { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "NumberOfPrizes", ResourceType = typeof(Resources.Texts))]
        public int NumberOfPrizes { get; set; }

        public string UserId { get; set; }
    }
}