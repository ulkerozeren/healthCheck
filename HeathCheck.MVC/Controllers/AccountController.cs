using HeathCheck.MVC.ApiServices.Interfaces;
using HeathCheck.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeathCheck.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthApiService _authService;

        public AccountController(IAuthApiService authService)
        {
            _authService = authService;
        }
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.SignIn(model);

                HttpContext.Session.SetInt32("userId", result.UserId);

                if (result != null)
                    return RedirectToAction("Index", "Home", new { userId = result.UserId });
            }

            return View();
        }

        public async Task<IActionResult> SignOut()
        {
            HttpContext.Session.Remove("userId");
            return RedirectToAction("SignIn", "Account");
        }

    }
}
