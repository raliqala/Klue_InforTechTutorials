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
    public class ProgrammingCoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tutorial
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> CSharp()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "C#");
            return View(await tutorials.ToListAsync());
        }
        public async Task<ActionResult> CPlusPlus()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "C++");
            return View(await tutorials.ToListAsync());
        }
        public async Task<ActionResult> C()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "C");
            return View(await tutorials.ToListAsync());
        }
        public async Task<ActionResult> PHP()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "PHP");
            return View(await tutorials.ToListAsync());
        }
        public async Task<ActionResult> Java()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "Java");
            return View(await tutorials.ToListAsync());
        }
        public async Task<ActionResult> JavaScript()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "JavaScript");
            return View(await tutorials.ToListAsync());
        }
        public async Task<ActionResult> Python()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "Python");
            return View(await tutorials.ToListAsync());
        }
        public async Task<ActionResult> Ruby()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "Ruby");
            return View(await tutorials.ToListAsync());
        }
        public async Task<ActionResult> HTML()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "HTML");
            return View(await tutorials.ToListAsync());
        }
        public async Task<ActionResult> CSS()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "CSS");
            return View(await tutorials.ToListAsync());
        }
        public async Task<ActionResult> Bash()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "Bash");
            return View(await tutorials.ToListAsync());
        }
        public async Task<ActionResult> ObjectC()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "Object C");
            return View(await tutorials.ToListAsync());
        }
        public async Task<ActionResult> VisualBasic()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "Visual Basic");
            return View(await tutorials.ToListAsync());
        }
        public async Task<ActionResult> Fsharp()
        {
            var tutorials = db.Tutorials.Where(t => t.CoursesName == "F#");
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