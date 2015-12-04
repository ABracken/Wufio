using System.ComponentModel.DataAnnotations;

namespace Wufio.Core
{
    public class RegisterRescuePrimaryModel
    {
        [Required]
        [Display(Name = "Rescue name")]
        public string RescueName { get; set; }

        [Required]
        [Display(Name = "Link to 501c3")]
        public string NonProfitLink { get; set; }

        [Required]
        [Display(Name = "Email address")]
        public string RescueEmail { get; set; }

        [Display(Name = "Address1")]
        public string Address1 { get; set; }

        [Display(Name = "Address2")]
        public string Address2 { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zipcode")]
        public string Zipcode { get; set; }

        [Display(Name = "Rescue Profile Picture")]
        public string RescueImageUrl { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Profile Picture")]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}