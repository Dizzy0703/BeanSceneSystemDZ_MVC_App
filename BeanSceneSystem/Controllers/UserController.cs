using Microsoft.AspNetCore.Mvc;
using BeanSceneSystem.Services;
using BeanSceneSystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace BeanSceneSystem.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserService _authService;

        public UserController(IUserService authService)
        {
            _authService = authService;
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (!ModelState.IsValid) { return View(model); }
            model.Role = "admin";
            var result = await _authService.RegisterAsync(model);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Registration));
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(RegistrationModel model)
        {
            if (!ModelState.IsValid) { return View(model); }
            model.Role = "admin";
            var result = await _authService.RegisterAsync(model);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Registration));
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await _authService.LoginAsync(model);
            if (result.StatusCode == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }

        //Logout
        //[Authorize]
        public async Task<IActionResult> Logout()
        {
            await this._authService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }

        // Go to Change Password page with no provided data.
        public IActionResult ChangePassword()
        {
            return View();
        }

        // Go to Change password page with provided data and subsequent validation.
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await _authService.ChangePasswordAsync(model, User.Identity.Name);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(ChangePassword));
        }
    }
}
