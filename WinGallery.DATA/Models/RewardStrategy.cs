namespace WinGallery.DATA.Models
{
    using System.Collections.Generic;
    using CommonLogic;
    using System.ComponentModel.DataAnnotations;
    using Common;

    public class RewardStrategy : BaseModel
    {
        public RewardStrategy()
        {
            this.Contests = new HashSet<Contest>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.RewardStrategyNameMinLength, ErrorMessage = DataConstants.RewardStrategyNameErrorMessage)]
        [MaxLength(DataConstants.RewardStrategyNameMaxLength, ErrorMessage = DataConstants.RewardStrategyNameErrorMessage)]
        public string Name { get; set; }

        [MaxLength(DataConstants.RewardStrategyNameMaxLength, ErrorMessage = DataConstants.RewardStrategyNameErrorMessage)]
        public string Description { get; set; }

        [Required]
        [Range(0, 20)]
        public int NumberOfPrizes { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Contest> Contests { get; set; }
    }
}
