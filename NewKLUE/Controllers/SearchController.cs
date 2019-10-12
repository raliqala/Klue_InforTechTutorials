using NewKLUE.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NewKLUE.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
                ApplicationDbContext db = new ApplicationDbContext();
        //GET: TutorialSearch

        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;

            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CourseSortParm = string.IsNullOrEmpty(sortOrder) ? "course" : "";
            ViewBag.TopicSortParm = string.IsNullOrEmpty(sortOrder) ? "topic" : "";
            ViewBag.ContentSortParm = string.IsNullOrEmpty(sortOrder) ? "content" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var tutorial = from s in db.Tutorials
                           select s;
            if (!string.IsNullOrEmpty(searchString))
            {
                tutorial = tutorial.Where(s => s.CoursesName.Contains(searchString)
                                       || s.Topic.Contains(searchString) ||
                                       s.Description.Contains(searchString) 
                                       || s.User.FirstName.Contains(searchString)
                                       || s.Content.Contains(searchString));
            }

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            int count = tutorial.Count();
            if (count == 0)
            {
                ViewBag.Message = " Sorry! no results " + searchString;
            }
            else if(count > 0)
            {
                ViewBag.Message = count + " Results " + searchString;
            }
           

            switch (sortOrder)
            {
                case "name_desc":
                    tutorial = tutorial.OrderByDescending(s => s.User.FirstName);
                    break;
                case "Date":
                    tutorial = tutorial.OrderBy(s => s.CreatedOn);
                    break;
                case "date_desc":
                    tutorial = tutorial.OrderByDescending(s => s.CreatedOn);
                    break;
                case "course":
                    tutorial = tutorial.OrderBy(s => s.CoursesName);
                    break;
                case "topic":
                    tutorial = tutorial.OrderByDescending(s => s.Topic);
                    break;
                case "content":
                    tutorial = tutorial.OrderByDescending(s => s.Content);
                    break;
                default:
                    tutorial = tutorial.OrderBy(s => s.User.FirstName);
                    break;
            }


            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(tutorial.ToPagedList(pageNumber, pageSize));
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
    }
}