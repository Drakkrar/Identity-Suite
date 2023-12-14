using Identity_Suite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity_Suite.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
		private void ErrorValidator(IdentityResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(String.Empty, error.Description);
			}

		}

		public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        // HTTP Get
        [HttpGet]
        public async Task<IActionResult> Create(string? returnurl = null)
        {
			ViewData["ReturnUrl"] = returnurl;
			RegisterViewModel registerViewModel = new RegisterViewModel();
            return View(registerViewModel);
        }

        [HttpGet]
        public IActionResult Login(string? returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            return View();
        }

        //HTTP Post
        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(RegisterViewModel registerViewModel, string? returnurl = null)
        {
			ViewData["ReturnUrl"] = returnurl;
			returnurl = returnurl ?? Url.Content("~/");
			if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = registerViewModel.Email,
                    Email = registerViewModel.Email,
                    Name = registerViewModel.Name,
                    PhoneNumber = registerViewModel.PhoneNumber,
                    Birthdate = registerViewModel.Birthdate
                };

                var response = await _userManager.CreateAsync(user, registerViewModel.Password);


                if(response.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return LocalRedirect(returnurl);
                }

                ErrorValidator(response);
            }

            return View(registerViewModel);
        }

        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(AccessViewModel accessViewModel, string? returnurl = null)
        {
			ViewData["ReturnUrl"] = returnurl;
			returnurl = returnurl ?? Url.Content("~/");
			if (ModelState.IsValid)
            {
                var response = await _signInManager.PasswordSignInAsync(accessViewModel.Email, accessViewModel.Password, accessViewModel.RememberMe, lockoutOnFailure: false);

                if (response.Succeeded)
                {
                    return LocalRedirect(returnurl);
                } else
                {
                    ModelState.AddModelError(string.Empty, "Not a valid access.");
                    return View(accessViewModel);
                }
            }

            return View(accessViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

    }
}
