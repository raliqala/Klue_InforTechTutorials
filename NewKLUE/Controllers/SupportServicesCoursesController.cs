using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewKLUE.Models;
using Microsoft.AspNet.Identity;

namespace NewKLUE.Controllers
{
    public class SupportServicesCoursesController : Controller
    {
        // GET: SupportServicesCourses
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tutorial
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> InstallationManagement()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "Installation Management");
            return View(await tutorials.ToListAsync());
        }
        public async Task<ActionResult> SupportServices()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "Support Services");
            return View(await tutorials.ToListAsync());
        }
        public async Task<ActionResult> CommunicationNetworks()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "Communication Networks");
            return View(await tutorials.ToListAsync());
        }
        public async Task<ActionResult> GraphicalUserInterfaceDesign()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "Graphical User Interface Design");
            return View(await tutorials.ToListAsync());
        }
        public async Task<ActionResult> SoftwareApplicationDevelopment()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "Software Application Development");
            return View(await tutorials.ToListAsync());
        }
        public async Task<ActionResult> ComputerSystemsandNetworks()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "Computer Systems and Networks");
            return View(await tutorials.ToListAsync());
        }
        // GET: Tutorial/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutorial tutorial = await db.Tutorials.FindAsync(id);
            if (tutorial == null)
            {
                return HttpNotFound();
            }
            return View(tutorial);
        }
    }
}