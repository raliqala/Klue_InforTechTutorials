using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewKLUE.Controllers
{
    public class GuidAndHelpController : Controller
    {
        // GET: GuidAndHelp
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Guid()
        {
            return View();
        }
        public ActionResult Help()
        {
            return View();
        }
        public ActionResult Feedback()
        {
            return View();
        }
        public ActionResult ReportProblem()
        {
            return View();
        }
    }
}