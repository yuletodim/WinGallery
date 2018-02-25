namespace WinGallery.Services.Models.Contests
{
    using System;
    using WinGallery.DATA.Models;
    using WinGallery.Services.Mappings;

    public class ContestFormModel : IMapTo<Contest>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int RewardStrategyId { get; set; }

        public VotingStrategy VotingStrategy { get; set; }

        public ParticipationStrategy ParticipationStrategy { get; set; }

        public DeadlineStrategy DeadlineStrategy { get; set; }

        public int? NumberOfParticipants { get; set; }

        public DateTime? Deadline { get; set; }

        public string UserId { get; set; }
    }
}
