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
    public class FeedBackController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FeedBack
        public async Task<ActionResult> Index()
        {
            return View(await db.FeedBack.ToListAsync());
        }

        // GET: FeedBack/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedBack feedBack = await db.FeedBack.FindAsync(id);
            if (feedBack == null)
            {
                return HttpNotFound();
            }
            return View(feedBack);
        }

        // GET: FeedBack/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FeedBack/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Email,Title,Message,DateTime,IsChecked,UserId")] FeedBack feedBack)
        {
            if (ModelState.IsValid)
            {
                string UserId = User.Identity.GetUserId();
                feedBack.UserId = UserId;
                feedBack.DateTime = DateTime.Now;
                db.FeedBack.Add(feedBack);
                await db.SaveChangesAsync();
                ViewBag.Message = "Thank you for your feedback.";
                return RedirectToAction("Create", "FeedBack");
            }

            return View(feedBack);
        }

        // GET: FeedBack/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedBack feedBack = await db.FeedBack.FindAsync(id);
            if (feedBack == null)
            {
                return HttpNotFound();
            }
            return View(feedBack);
        }

        // POST: FeedBack/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Email,Title,Message,DateTime,IsChecked,UserId")] FeedBack feedBack)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedBack).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(feedBack);
        }

        // GET: FeedBack/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedBack feedBack = await db.FeedBack.FindAsync(id);
            if (feedBack == null)
            {
                return HttpNotFound();
            }
            return View(feedBack);
        }

        // POST: FeedBack/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FeedBack feedBack = await db.FeedBack.FindAsync(id);
            db.FeedBack.Remove(feedBack);
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
