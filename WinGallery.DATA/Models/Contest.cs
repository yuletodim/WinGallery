namespace WinGallery.DATA.Models
{
    using CommonLogic;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Common.DataConstants;

    public class Contest : BaseModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ContestTitleMinLength, ErrorMessage = ContestTitleErrorMessage)]
        [MaxLength(ContestTitleMaxLength, ErrorMessage = ContestTitleErrorMessage)]
        public string Title { get; set; }

        [Required]
        [MinLength(ContestDescriptionMinLength, ErrorMessage = ContestDescriptionErrorMessage)]
        [MaxLength(ContestDescriptionMaxLength, ErrorMessage = ContestDescriptionErrorMessage)]
        public string Description { get; set; }

        [Required]
        public int RewardStrategyId { get; set; }

        public virtual RewardStrategy RewardStrategy { get; set; }

        [Required]
        public VotingStrategy VotingStrategy { get; set; }

        [Required]
        public ParticipationStrategy ParticipationStrategy { get; set; }

        [Required]
        public DeadlineStrategy DeadlineStrategy { get; set; }

        public int? NumberOfParticipants { get; set; }

        public DateTime? Deadline { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; } = new HashSet<Picture>();

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }
    } 
}
