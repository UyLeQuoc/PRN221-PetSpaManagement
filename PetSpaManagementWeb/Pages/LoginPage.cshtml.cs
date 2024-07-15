using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepositoryLayer.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PetSpaManagementWeb.Pages
{
    public class LoginPageModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public LoginPageModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [BindProperty]
        public LoginModel LoginModel { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var user = await _userRepository.LoginAsync(LoginModel.Email, LoginModel.Password);
                if (user == null)
                {
                    ErrorMessage = "Incorrect email or password.";
                    return Page();
                }

                HttpContext.Session.SetString("Token", user.Token);
                HttpContext.Session.SetString("Email", user.User.Email);
                HttpContext.Session.SetString("Name", user.User.Name);
                HttpContext.Session.SetInt32("RoleId", user.User.RoleId ?? 4);

                switch (user.User.RoleId)
                {
                    case 1:
                        return RedirectToPage("/AdminDashboard/Index");

                    case 2:
                        return RedirectToPage("/ManagerDashboard/Index");

                    case 3:
                        return RedirectToPage("/PetSitterDashboard/Index");

                    case 4:
                        return RedirectToPage("/Pets/Index");

                    default:
                        return RedirectToPage("/Index");
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                ErrorMessage = ex.Message;
                return Page();
            }
        }
    }

    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}