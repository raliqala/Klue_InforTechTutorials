using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NewKLUE.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ICollection<TutorToProgramming> TutorToProgramming { get; set; }
        public virtual ICollection<Tutorial> Tutorials { get; set; }
        public virtual ICollection<FeedBack> FeedBack { get; set; }
        public virtual ICollection<ReportProblem> ReportProblem { get; set; }
        public virtual ICollection<ClassRoom> classroom { get; set; }

        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string UserBio { get; set; }
        public byte[] UserPhoto { get; set; }
        public string WebUrl { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string YouTube { get; set; }
        public string GitHub { get; set; }
        public string Dribble { get; set; }
        public string CompanyName { get; set; }

        public const string DisplayNameClaimType = "FirstName";

        
        

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim(DisplayNameClaimType, FirstName));
            return userIdentity;
        }

    //    public static implicit operator ApplicationUser(ApplicationUser v)
    //    {
    //        throw new NotImplementedException();
    //    }
    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName) : base(roleName) { }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            System.Data.Entity.Core.Objects.ObjectContext objectContext = (this as IObjectContextAdapter).ObjectContext;
            objectContext.CommandTimeout = 180;
        }

        public DbSet<Subscribe> Subscribe { get; set; }
        public DbSet<FeedBack> FeedBack { get; set; }
        public DbSet<ReportProblem> ReportProblem { get; set; }
        public DbSet<FileDetail> FileDetail { get; set; }
        public DbSet<Programming> Programming { get; set; }
        public DbSet<Tutorial> Tutorials { get; set; }
        public DbSet<VoteLog> VoteLog { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<TutorToProgramming> TutorToProgramming { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // configures one-to-many relationship
            modelBuilder.Entity<Tutorial>()
                .HasRequired(s => s.User)
                .WithMany(g => g.Tutorials)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Properties<DateTime>()
          .Configure(c => c.HasColumnType("datetime2"));
        }

        
    }
}
