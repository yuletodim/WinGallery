namespace WinGallery.Services.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using WinGallery.DATA.Models;
    using WinGallery.DATA.Repositories;
    using WinGallery.Services.Interfaces;
    using WinGallery.Services.Mappings;
    using WinGallery.Services.Models.RewardStrategies;
    using System.Threading.Tasks;
    using System.Data.Entity;

    public class RewardStrategyServices : BaseServices, IRewardStrategyServices
    {
        private readonly IDbRepository<RewardStrategy, int> rewardStrategiesRepository;

        public RewardStrategyServices(IDbRepository<RewardStrategy, int> rewardStrategiesRepository)
        {
            this.rewardStrategiesRepository = rewardStrategiesRepository;
        }

        public void Add(RewardStrategyFormModel model)
        {
            var rewardStrategy = this.Mapper.Map<RewardStrategy>(model);
            this.rewardStrategiesRepository.Add(rewardStrategy);

            this.rewardStrategiesRepository.SaveChanges();

        }

        public async Task<IEnumerable<RewardStrategyModel>> GetAllAsync()
            => await this.rewardStrategiesRepository
                .GetAll()
                .To<RewardStrategyModel>()
                .OrderByDescending(rs => rs.CreatedOn)
                .ToListAsync();

        public IEnumerable<RewardStrategyModel> GetAllForSelection()
            => 
    }
}
