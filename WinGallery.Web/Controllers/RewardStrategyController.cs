namespace WinGallery.Web.Controllers
{
    using Microsoft.AspNet.Identity;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using WinGallery.DATA.Common;
    using WinGallery.DATA.Models;
    using WinGallery.Services.Interfaces;
    using WinGallery.Services.Models.RewardStrategies;
    using WinGallery.Web.Models.RewardStrategies;

    [Authorize(Roles = DataConstants.AdminRole + ", " + DataConstants.ModeratorRole)]
    public class RewardStrategiesController : BaseController
    {
        private readonly IRewardStrategyServices rewardStrategyServices;
        private readonly UserManager<User> userManger;

        public RewardStrategiesController(
            IRewardStrategyServices rewardStrategyServices,
            UserManager<User> userManger)
        {
            this.rewardStrategyServices = rewardStrategyServices;
            this.userManger = userManger;
        }

        public async Task<ActionResult> Index()
            => this.View(await this.rewardStrategyServices.GetAllAsync());

        public ActionResult Add()
            => this.View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(RewardStrategyBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.User.Identity.GetUserId();
            model.UserId = userId;
            var rewardStrategy = this.Mapper.Map<RewardStrategyFormModel>(model);

            this.rewardStrategyServices.Add(rewardStrategy);

            return this.RedirectToAction(nameof(Index));
        }
    }
}