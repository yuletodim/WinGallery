namespace WinGallery.Web.Models
{
    using System.Collections.Generic;
    using WinGallery.Services.Mappings;
    using WinGallery.Services.Models;

    public class ContestViewModel : IMapFrom<ContestModel>, IMapTo<ContestModel>
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int RewardStrategyID { get; set; }

        public string RewardStrategyName { get; set; }

        public int VotingStrategyID { get; set; }

        public string VotingStrategyName { get; set; }

        public int ParticipationStrategyID { get; set; }

        public string ParticipationStrategyName { get; set; }

        public string MostVotedPicture { get; set; }

        public int DeadlineStrategyID { get; set; }

        public string DeadlineStrategyName { get; set; }

        public virtual IEnumerable<PictureViewModel> Pictures { get; set; }
    }
}