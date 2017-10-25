namespace WinGallery.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using WinGallery.Services.Interfaces;
    using Models;

    [Authorize]
    public class HomeController : BaseController
    {
        private readonly IContestsServices contestsServices;
        private readonly IUsersServices usersServices;

        public HomeController(IUsersServices usersServices, IContestsServices contestsService)
        {
            this.contestsServices = contestsService;
            this.usersServices = usersServices;
        }

        public ActionResult Index()
        {
            var contests = this.contestsServices.GetAll();
            //var users = this.usersServices.GetAll();
            //var usersViewModel = this.Mapper.Map<List<UserViewModel>>(users);
            return View(contests);
        }

    }
}