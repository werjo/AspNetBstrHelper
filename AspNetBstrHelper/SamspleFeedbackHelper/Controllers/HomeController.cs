using AspNetBstrHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleFeedbackHelper.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateFeedBack(bool success = true, string message = "Feedback Beispiel")
        {
            FeedbackHelper.BuildTempDate(success, message, TempData);
            return RedirectToAction("Index");
        }
    }
}