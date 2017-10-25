namespace WinGallery.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Models;
    using Services.Interfaces;
    using Services.Services;

    public class ContestsController : BaseController
    {
        private readonly IContestsServices contestServices;

        public ContestsController(IContestsServices contestServices)
        {
            this.contestServices = contestServices;
        }

        // GET Contests/View/id
        public ActionResult View(int id)
        {
            var contest = this.contestServices.GetById(id);
            var contestViewModel = this.Mapper.Map<ContestViewModel>(contest);

            return this.View(contestViewModel);
        }
    }
}