using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewKLUE.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Net;
using System.IO;

namespace NewKLUE.Controllers
{
    [Authorize(Roles = "Tutor")]
    public class ClassController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Class
        public async Task<ActionResult> Index()
        {
            string CurrentUserId = User.Identity.GetUserId();
            var tutorials = db.Tutorials.Where(t => t.UserId == CurrentUserId);
            return View(await tutorials.ToListAsync());
        }
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


         public ActionResult Create()
        {
            return View();
        }

        // POST: Tutorial/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TutorialId,Topic,CoursesName,Description,Content,UserId,CreatedOn")] Tutorial tutorial)
        {
            if (ModelState.IsValid)
            {
                List<FileDetail> fileDetails = new List<FileDetail>();

                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];
                  
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            FileDetail fileDetail = new FileDetail()
                            {
                                FileName = fileName,
                                Extension = Path.GetExtension(fileName),
                                Id = Guid.NewGuid(),
                                Date = DateTime.Now
                            };
                            fileDetails.Add(fileDetail);

                            var path = Path.Combine(Server.MapPath("~/App_Data/Upload/"), fileDetail.Id + fileDetail.Extension);
                            file.SaveAs(path);
                        }
                }
                tutorial.FileDetail = fileDetails;
                tutorial.CreatedOn = DateTime.Now;
                var UserId = User.Identity.GetUserId();
                tutorial.UserId = UserId;

                db.Tutorials.Add(tutorial);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

           
            return View(tutorial);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Tutorial tutorial = await db.Tutorials.FindAsync(id);
            Tutorial tutorials = db.Tutorials.Include(s => s.FileDetail).SingleOrDefault(x => x.TutorialId == id);
            if (tutorials == null)
            {
                return HttpNotFound();
            }

            return View(tutorials);
        }

        // POST: Tutorial/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TutorialId,Topic,CoursesName,Description,Content,UserId,CreateOn")] Tutorial tutorial)
        {
            if (ModelState.IsValid)
            {
                //New Files
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        FileDetail fileDetail = new FileDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid(),
                            TutorialId = tutorial.TutorialId
                        };
                        var path = Path.Combine(Server.MapPath("~/App_Data/Upload/"), fileDetail.Id + fileDetail.Extension);
                        file.SaveAs(path);

                        db.Entry(fileDetail).State = EntityState.Added;
                    }
                }

                tutorial.CreatedOn = DateTime.Now;
                string UserId = User.Identity.GetUserId();
                tutorial.UserId = UserId;
                db.Entry(tutorial).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tutorial);
        }

        [AllowAnonymous]
        public FileResult Download(String p, String d)
        {
            return File(Path.Combine(Server.MapPath("~/App_Data/Upload/"), p), System.Net.Mime.MediaTypeNames.Application.Octet, d);
        }

        [HttpPost]
        public JsonResult DeleteFile(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = "Error" });
            }
            try
            {
                Guid guid = new Guid(id);
                FileDetail fileDetail = db.FileDetail.Find(guid);
                if (fileDetail == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.FileDetail.Remove(fileDetail);
                db.SaveChanges();

                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/App_Data/Upload/"), fileDetail.Id + fileDetail.Extension);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }
        }
        // GET: Tutorial/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Tutorial tutorial = await db.Tutorials.FindAsync(id);
            Tutorial tutorials = db.Tutorials.Include(s => s.FileDetail).SingleOrDefault(x => x.TutorialId == id);
            if (tutorials == null)
            {
                return HttpNotFound();
            }
            return View(tutorials);
        }

        // POST: Tutorial/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id, Tutorial tutorial)
        //{
        //    //Tutorial tutorial = new Tutorial();
        //    foreach (var item in tutorial.FileDetail)
        //    {
        //        string path = Path.Combine(Server.MapPath("~/App_Data/Upload/"), item.Id + item.Extension);
        //        if (System.IO.File.Exists(path))
        //        {
        //            System.IO.File.Delete(path);
        //        }
        //    }
        //    tutorial = await db.Tutorials.FindAsync(id);
        //    db.Tutorials.Remove(tutorial);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                Tutorial tutorial = db.Tutorials.Find(id);
                if (tutorial == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //delete files from the file system

                foreach (var item in tutorial.FileDetail)
                {
                    String path = Path.Combine(Server.MapPath("~/App_Data/Upload/"), item.Id + item.Extension);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }

                db.Tutorials.Remove(tutorial);
                db.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }
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