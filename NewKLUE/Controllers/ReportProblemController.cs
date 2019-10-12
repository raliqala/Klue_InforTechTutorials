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
using Microsoft.AspNet.Identity;

namespace NewKLUE.Controllers
{
    public class ReportProblemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ReportProblem
        public async Task<ActionResult> Index()
        {
            return View(await db.ReportProblem.ToListAsync());
        }

        // GET: ReportProblem/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportProblem reportProblem = await db.ReportProblem.FindAsync(id);
            if (reportProblem == null)
            {
                return HttpNotFound();
            }
            return View(reportProblem);
        }

        // GET: ReportProblem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReportProblem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Email,Title,Message,DateTime,IsChecked,UserId")] ReportProblem reportProblem)
        {
            if (ModelState.IsValid)
            {
                string UserId = User.Identity.GetUserId();
                reportProblem.UserId = UserId;
                reportProblem.DateTime = DateTime.Now;

                db.ReportProblem.Add(reportProblem);
                await db.SaveChangesAsync();
                ViewBag.Message = "Thank you we received your report.";
                return RedirectToAction("Create", "ReportProblem");
            }

            return View(reportProblem);
        }

        // GET: ReportProblem/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportProblem reportProblem = await db.ReportProblem.FindAsync(id);
            if (reportProblem == null)
            {
                return HttpNotFound();
            }
            return View(reportProblem);
        }

        // POST: ReportProblem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Email,Title,Message,DateTime,IsChecked,UserId")] ReportProblem reportProblem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportProblem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(reportProblem);
        }

        // GET: ReportProblem/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportProblem reportProblem = await db.ReportProblem.FindAsync(id);
            if (reportProblem == null)
            {
                return HttpNotFound();
            }
            return View(reportProblem);
        }

        // POST: ReportProblem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ReportProblem reportProblem = await db.ReportProblem.FindAsync(id);
            db.ReportProblem.Remove(reportProblem);
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
