using System.ComponentModel.DataAnnotations;

namespace Identity_Suite.Models
{

    public class RegisterViewModel
    {

        // TODO: Change all error messages to use locale model.
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "{0} must have at least {2} chars lenght", MinimumLength = 4)]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [Display(Description = "Test")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, ErrorMessage = "{0} must have at least {2} chars lenght", MinimumLength = 12)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "The provided value doesn't coincide.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public RegisterViewModel() { Birthdate = DateTime.Today; }

    }
}
