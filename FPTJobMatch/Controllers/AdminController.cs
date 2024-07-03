using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace FPTJobMatch.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RoleList()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (!string.IsNullOrEmpty(roleName))
            {
                var role = new IdentityRole(roleName);
                var result = await _roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(roleName);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> SetRole()
        {
            var users = await _userManager.Users.Select(u => u.UserName).ToListAsync();
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> SetRole(string userId, string role)
        {
            var user = await _userManager.FindByNameAsync(userId);
            if (user == null)
            {
                return NotFound("This user does not exist.");
            }

            var roleExists = await _roleManager.RoleExistsAsync(role);
            if (!roleExists)
            {
                return NotFound("This role does not exist.");
            }

            await _userManager.AddToRoleAsync(user, role);

            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UserList()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }

        public async Task<IActionResult> ResetPassword(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var newPassword = GenerateRandomPassword();

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            if (!result.Succeeded)
            {
                return BadRequest();
            }

            TempData["NewPassword"] = newPassword;

            return RedirectToAction("UserList");
        }

        private string GenerateRandomPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+";

            var random = new Random();
            var upperIndex = random.Next(0, 25);
            var specialIndex = random.Next(52, 61);
            var digitIndex = random.Next(62, 71);

            var password = new StringBuilder();
            password.Append(chars[random.Next(0, 25)]);
            password.Append(chars[random.Next(26, 51)]);
            password.Append(chars[random.Next(52, 61)]);
            password.Append(chars[random.Next(62, 71)]);

            for (int i = 4; i < 8; i++)
            {
                password.Append(chars[random.Next(chars.Length)]);
            }

            var shuffledPassword = new string(password.ToString().OrderBy(x => random.Next()).ToArray());

            return shuffledPassword;
        }
    }
}