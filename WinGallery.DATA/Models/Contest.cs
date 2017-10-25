namespace WinGallery.DATA.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using CommonLogic;

    public class Contest : BaseModel
    {
        public Contest()
        {
            this.Pictures = new HashSet<Picture>();
        }

        [Key]
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [ForeignKey("RewardStrategy")]
        public int RewardStrategyID { get; set; }

        public virtual RewardStrategy RewardStrategy { get; set; }

        [ForeignKey("VotingStrategy")]
        public int VotingStrategyID { get; set; }

        public virtual VotingStrategy VotingStrategy { get; set; }

        [ForeignKey("ParticipationStrategy")]
        public int ParticipationStrategyID { get; set; }

        public virtual ParticipationStrategy ParticipationStrategy { get; set; }

        [ForeignKey("DeadlineStrategy")]
        public int DeadlineStrategyID { get; set; }

        public virtual DeadlineStrategy DeadlineStrategy { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }
    }
   
}
