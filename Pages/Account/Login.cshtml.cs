using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using WebApplication5.Data;
using WebApplication5.Models;
using System.Linq;

namespace WebApplication5.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly LoginDbContext _context;

        public LoginModel(LoginDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LoginInput Input { get; set; } = new();

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = _context.Users
                .FirstOrDefault(u => u.Username == Input.Email && u.Password == Input.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid login credentials.");
                return Page();
            }

            TempData["UserName"] = user.Username;
            TempData["LoginMessage"] = "Login successful!";
            return RedirectToPage("/Dashboard");
        }

        public class LoginInput
        {
            [Required]
            public string Email { get; set; } = string.Empty;

            [Required]
            public string Password { get; set; } = string.Empty;
        }
    }
}
