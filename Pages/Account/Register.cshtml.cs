using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly LoginDbContext _context;

        public RegisterModel(LoginDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RegisterInput Input { get; set; } = new();

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Input.Password != Input.ConfirmPassword)
            {
                ModelState.AddModelError("", "Passwords do not match");
                return Page();
            }

            // Check if email already exists in DB
            if (_context.Users.Any(u => u.Username == Input.Email))
            {
                TempData["RegisterMessage"] = "Account already registered.";
                return Page();
            }

            // Save to database
            var user = new User
            {
                Username = Input.Email!,
                Password = Input.Password! // In production, encrypt this!
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            TempData["RegisterMessage"] = "Registration successful! Please log in.";
            return RedirectToPage("/Account/Login");
        }

        public class RegisterInput
        {
            [Required]
            public string? FirstName { get; set; }
            [Required]
            public string? LastName { get; set; }
            [Required]
            [EmailAddress]
            public string? Email { get; set; }
            [Required]
            public string? Password { get; set; }
            [Required]
            public string? ConfirmPassword { get; set; }
        }
    }
}
