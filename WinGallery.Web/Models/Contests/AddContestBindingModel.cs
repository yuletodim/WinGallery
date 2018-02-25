namespace WinGallery.Web.Models.Contests
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using WinGallery.Services.Mappings;
    using WinGallery.Services.Models.Contests;

    using DATA.Common;
    using WinGallery.DATA.Models;
    using System.Collections.Generic;

    public class AddContestBindingModel : IMapTo<ContestFormModel>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.ContestTitleMinLength, ErrorMessage = DataConstants.ContestTitleErrorMessage)]
        [MaxLength(DataConstants.ContestTitleMaxLength, ErrorMessage = DataConstants.ContestTitleErrorMessage)]
        [Display(Name = "Title", ResourceType = typeof(Resources.Texts))]
        public string Title { get; set; }

        [Required]
        [MinLength(DataConstants.ContestDescriptionMinLength, ErrorMessage = DataConstants.ContestDescriptionErrorMessage)]
        [MaxLength(DataConstants.ContestDescriptionMaxLength, ErrorMessage = DataConstants.ContestDescriptionErrorMessage)]
        [Display(Name = "Description", ResourceType = typeof(Resources.Texts))]
        public string Description { get; set; }

        [Required]
        [Display(Name = "RewardStrategy", ResourceType = typeof(Resources.Texts))]
        public int RewardStrategyId { get; set; }

        [Required]
        [Display(Name = "VotingStrategy", ResourceType = typeof(Resources.Texts))]
        public VotingStrategy VotingStrategy { get; set; }

        [Required]
        [Display(Name = "ParticipationStrategy", ResourceType = typeof(Resources.Texts) )]
        public ParticipationStrategy ParticipationStrategy { get; set; }

        [Required]
        [Display(Name = "DeadlineStrategy", ResourceType = typeof(Resources.Texts))]
        public DeadlineStrategy DeadlineStrategy { get; set; }

        [Display(Name = "NumberOfParticipants", ResourceType = typeof(Resources.Texts))]
        public int? NumberOfParticipants { get; set; }

        [Display(Name = "Deadline", ResourceType = typeof(Resources.Texts))]
        public DateTime? Deadline { get; set; }

        public string UserId { get; set; }

        public IEnumerable<RewardStretegyShortModel> RewardStrategies { get; set; }
    }
}