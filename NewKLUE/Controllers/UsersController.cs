using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using NewKLUE.Models;


namespace NewKLUE.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Students
        public ActionResult Index(string id)
        {
            var user = db.Users.Where(u => u.UserName == id);

            return View(user);
        }

        public ActionResult Details(string id)
        {
            string username = User.Identity.Name;

            // Fetch the userprofile
            ApplicationUser user = db.Users.FirstOrDefault(u => u.UserName.Equals(username));
            ApplicationUser model = new ApplicationUser();

            var MyViewModel = new UsersViewModel();

            var Results = from b in db.Programming
                          select new
                          {
                              b.ProgrammingId,
                              b.Name,
                              Checked = ((from ab in db.TutorToProgramming
                                          where (ab.UserId == user.Id) & (ab.ProgrammingId == b.ProgrammingId)
                                          select ab).Count() > 0)
                          };


            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.ProgrammingId, Name = item.Name, Checked = item.Checked });
            }


            MyViewModel.Programming = MyCheckBoxList;

            ViewBag.courses = Results;
            return View(MyViewModel);
        }

        public ActionResult Edit()
        {
            string username = User.Identity.Name;

            // Fetch the userprofile
            ApplicationUser user = db.Users.FirstOrDefault(u => u.UserName.Equals(username));

            // Construct the viewmodel
            ApplicationUser model = new ApplicationUser();
            var MyViewModel = new UsersViewModel();
            if (User.IsInRole("Student"))
            {
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.Email = user.Email;
                model.Country = user.Country;
                model.Region = user.Region;
                model.PasswordHash = user.PasswordHash;
                model.UserBio = user.UserBio;
             
            }
            else
            {
        
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.Email = user.Email;
                model.Country = user.Country;
                model.Region = user.Region;
                model.PasswordHash = user.PasswordHash;
                model.PhoneNumber = user.PhoneNumber;
                model.UserBio = user.UserBio;
                model.WebUrl = user.WebUrl;
                model.CompanyName = user.CompanyName;
                model.Facebook = user.Facebook;
                model.Twitter = user.Twitter;
                model.GitHub = user.GitHub;
                model.YouTube = user.YouTube;
                user.Dribble = user.Dribble;

                var Results = from b in db.Programming
                              select new
                              {
                                  b.ProgrammingId,
                                  b.Name,
                                  Checked = ((from ab in db.TutorToProgramming
                                              where (ab.UserId == user.Id) & (ab.ProgrammingId == b.ProgrammingId)
                                              select ab).Count() > 0)
                              };


                MyViewModel.UserId = model.Id;
                MyViewModel.FirstName = user.FirstName;
                MyViewModel.LastName = user.LastName;
                MyViewModel.Email = user.Email;
                MyViewModel.Country = user.Country;
                MyViewModel.Region = user.Region;
                MyViewModel.UserBio = user.UserBio;
                MyViewModel.WebUrl = user.WebUrl;
                MyViewModel.CompanyName = user.CompanyName;
                MyViewModel.Facebook = user.Facebook;
                MyViewModel.Twitter = user.Twitter;
                MyViewModel.GitHub = user.GitHub;
                MyViewModel.Youtube = user.YouTube;
                MyViewModel.Dribble = user.Dribble;

                var MyCheckBoxList = new List<CheckBoxViewModel>();

                foreach (var item in Results)
                {
                    MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.ProgrammingId, Name = item.Name, Checked = item.Checked });
                }


                MyViewModel.Programming = MyCheckBoxList;
            }

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(MyViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsersViewModel userprofile)
        {
            if (ModelState.IsValid)
            {
                string username = User.Identity.Name;
                // Get the userprofile
                ApplicationUser user = db.Users.FirstOrDefault(u => u.UserName.Equals(username));
                string CureentUserId = User.Identity.GetUserId();

                ApplicationUser MyUser = db.Users.Find(User.Identity.GetUserId());
                // Update fields
                if (User.IsInRole("Student"))
                {
                    user.FirstName = userprofile.FirstName;
                    user.LastName = userprofile.LastName;
                    user.Email = userprofile.Email;
                    user.Country = userprofile.Country;
                    user.Region = userprofile.Region;
                    user.UserBio = userprofile.UserBio;

                    MyUser.FirstName = userprofile.FirstName;
                    MyUser.LastName = userprofile.LastName;
                    MyUser.Email = userprofile.Email;
                    MyUser.Country = userprofile.Country;
                    MyUser.Region = userprofile.Region;
                    MyUser.UserBio = userprofile.UserBio;

                }
                else
                {
                    user.FirstName = userprofile.FirstName;
                    user.LastName = userprofile.LastName;
                    user.Email = userprofile.Email;
                    user.Country = userprofile.Country;
                    user.Region = userprofile.Region;
                    user.UserBio = userprofile.UserBio;
                    user.WebUrl = userprofile.WebUrl;
                    user.CompanyName = userprofile.CompanyName;
                    user.Facebook = userprofile.Facebook;
                    user.Twitter = userprofile.Twitter;
                    user.GitHub = userprofile.GitHub;
                    user.YouTube = userprofile.Youtube;
                    user.Dribble = userprofile.Dribble;



                    MyUser.FirstName = userprofile.FirstName;
                    MyUser.LastName = userprofile.LastName;
                    MyUser.Email = userprofile.Email;
                    MyUser.Country = userprofile.Country;
                    MyUser.Region = userprofile.Region;
                    MyUser.UserBio = userprofile.UserBio;
                    MyUser.WebUrl = userprofile.WebUrl;
                    MyUser.CompanyName = userprofile.CompanyName;
                    MyUser.Facebook = userprofile.Facebook;
                    MyUser.Twitter = userprofile.Twitter;
                    MyUser.GitHub = userprofile.GitHub;
                    MyUser.YouTube = userprofile.Youtube;
                    MyUser.Dribble = userprofile.Dribble;




                }

                foreach (var item in db.TutorToProgramming)
                {
                    if (item.UserId == user.Id)
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }
                }

                foreach (var item in userprofile.Programming)
                {
                    if (item.Checked)
                    {
                        db.TutorToProgramming.Add(new TutorToProgramming() { UserId = CureentUserId, ProgrammingId = item.Id });
                    }
                }

                db.SaveChangesAsync();
                return RedirectToAction("Index", "Users"); // or whatever
            }

            return View(userprofile);
        }


    }
}