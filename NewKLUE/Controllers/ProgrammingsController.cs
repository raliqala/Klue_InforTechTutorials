 using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewKLUE.Models;

namespace NewKLUE.Controllers
{
    public class ProgrammingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Programmings
        public async Task<ActionResult> Index()
        {
            return View(await db.Programming.ToListAsync());
        }

        // GET: Programmings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programming programming = await db.Programming.FindAsync(id);
            if (programming == null)
            {
                return HttpNotFound();
            }
            return View(programming);
        }

        // GET: Programmings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Programmings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProgrammingId,Name")] Programming programming)
        {
            if (ModelState.IsValid)
            {
                db.Programming.Add(programming);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(programming);
        }

        // GET: Programmings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programming programming = await db.Programming.FindAsync(id);
            if (programming == null)
            {
                return HttpNotFound();
            }
            return View(programming);
        }

        // POST: Programmings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProgrammingId,Name")] Programming programming)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programming).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(programming);
        }

        // GET: Programmings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programming programming = await db.Programming.FindAsync(id);
            if (programming == null)
            {
                return HttpNotFound();
            }
            return View(programming);
        }

        // POST: Programmings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Programming programming = await db.Programming.FindAsync(id);
            db.Programming.Remove(programming);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
