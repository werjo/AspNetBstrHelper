using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetBstrHelper;

namespace SampleAspNetBstrFeedback.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateFeedBack()
        {
            FeedbackHelper.BuildTempData(true, "Feedback", TempData);
            return RedirectToAction("Index");
        }
    }
}