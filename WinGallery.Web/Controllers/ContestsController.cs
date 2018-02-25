namespace WinGallery.Web.Controllers
{
    using Models;
    using Services.Interfaces;
    using System.Web.Mvc;
    using WinGallery.Web.Models.Contests;
    using System;

    [Authorize]
    public class ContestsController : BaseController
    {
        private readonly IContestsServices contestServices;

        public ContestsController(IContestsServices contestServices)
        {
            this.contestServices = contestServices;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        // GET Contests/View/id
        public ActionResult View(int id)
        {
            var contest = this.contestServices.GetById(id);
            var contestViewModel = this.Mapper.Map<ContestViewModel>(contest);

            return this.View(contestViewModel);
        }

        public ActionResult Add()
        {
            var contestModel = this.GetEmtpyModel();
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddContestBindingModel model)
        {
            return this.RedirectToAction(nameof(Index));
        }


        private object GetEmtpyModel()
        {
            throw new NotImplementedException();
        }
    }
}