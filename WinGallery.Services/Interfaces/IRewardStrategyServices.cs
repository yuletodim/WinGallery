namespace WinGallery.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WinGallery.Services.Models.RewardStrategies;

    public interface IRewardStrategyServices
    {
        Task<IEnumerable<RewardStrategyModel>> GetAllAsync()

        void Add(RewardStrategyFormModel model);

        IEnumerable<RewardStrategyModel> GetAllForSelection();
    }
}
