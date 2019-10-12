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
    public class NetworkingCoursesController : Controller
    {
        // GET: NetworkingCourses
       private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tutorial
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Mathematics()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "Mathematics");
            return View(await tutorials.ToListAsync());
        }
        public async Task<ActionResult> SystemsDevelopment()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "Systems Development");
            return View(await tutorials.ToListAsync());
        }
        public async Task<ActionResult> InternetIntranetandExtranet()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "Internet Intranet and Extranet");
            return View(await tutorials.ToListAsync());
        }
        public async Task<ActionResult> InformationSystemsinOrganizations()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "Information Systems in Organizations");
            return View(await tutorials.ToListAsync());
        }
        public async Task<ActionResult> DataCommunicationNetworks()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "Data Communication Networks");
            return View(await tutorials.ToListAsync());
        }
        public async Task<ActionResult> NetworkAchitecture()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "Network Achitecture");
            return View(await tutorials.ToListAsync());
        }
        public async Task<ActionResult> CommunicationNetwork()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "Communication Networks");
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