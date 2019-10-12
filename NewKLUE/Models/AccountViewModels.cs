using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.Security;

namespace NewKLUE.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string RoleName { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        [RegularExpression(@"(\S)+", ErrorMessage = "White spaces are not allowed.")]
        [StringLength(40, ErrorMessage = "The {0} must be at least {2} character long", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [RegularExpression(@"(\S)+", ErrorMessage = "White space is not allowed.")]
        [StringLength(40, ErrorMessage = "The {0} must be at least {2} character long", MinimumLength = 2)]
        public string Lastname { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [Remote("UserAlreadyExistsAsync", "Account", ErrorMessage = "User with this Email already exists")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "State/Region")]
        public string Region { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long<bvr/> and and contain at least one symbol<br/>, uppercases and lowercases<br/> (!, @, #, ''a'-'z', 'A'-'Z').", MinimumLength = 6)]
        [MembershipPassword(
        MinRequiredNonAlphanumericCharacters = 1,
        MinNonAlphanumericCharactersError = "Your password needs to contain at<br/> least one symbol, uppercases and <br/>lowercases (!, @, #, ''a'-'z', 'A'-'Z').",
        ErrorMessage = "Your password need to contain at least one symbol<br/> uppercases and lowercases<br/> (!, @, #, ''a'-'z', 'A'-'Z').",
        MinRequiredPasswordLength = 6
        )]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please select a role")]
        [Display(Name = "Select Role")]
        public string RoleName { get; set; }

        [StringLength(250, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [Display(Name = "Bio")]
        public string UserBio { get; set; }

        //ContentLength(4);

        [Display(Name = "Profile Picture")]
        public byte[] UserPhoto { get; set; }

        [Display(Name = "Your Website Url")]
        public string WebUrl { get; set; }

        [Display(Name = "Your Company Name")]
        public string CompanyName { get; set; }



    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
