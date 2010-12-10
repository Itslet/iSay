using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iSay.Infrastructure;

namespace iSay.Controllers
{
    public class HomeController : Controller
    {
        private IStoryRepository _repo;

        public HomeController(IStoryRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            var stories = _repo.getStories();
            return View(stories);
        }

    }
}
