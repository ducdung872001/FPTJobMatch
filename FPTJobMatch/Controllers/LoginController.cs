using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace FPTJobMatch.Controllers
{
    public class LoginController : Controller
    {
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            /// check account
            return RedirectToAction("Index", "Home");
        }

    }
}
