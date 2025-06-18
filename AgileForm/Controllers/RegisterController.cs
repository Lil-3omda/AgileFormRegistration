using AgileForm.Models;
using AgileForm.Models.Context;
using AgileForm.Models.ViewModel;
using AgileForm.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace AgileForm.Controllers
{
    public class RegisterController : Controller
    {
        UserRepository _user;
        public RegisterController()
        {
            _user = new UserRepository(); 
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(RegistrationViewModel registrationView)
        {
            if (!ModelState.IsValid)
                return View("Index", registrationView);


            var user = _user.GetByEmail(registrationView.Email);
            if (user != null && user.Password == registrationView.Password)
            {
                HttpContext.Session.SetString("UserEmail", user.Email);
                HttpContext.Session.SetString("UserName", user.Name);
                ViewData["Message"] = "Login successful!";
                return View("Welcome");
            }

            ModelState.AddModelError(string.Empty, "Invalid email or password.");
            return View("Index", registrationView);
        }

        public IActionResult SignUp()
        {
            return View("SignUp");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser(RegistrationViewModel registrationView)
        {
            if (!ModelState.IsValid)
            {
                return View("SignUp", registrationView);
            }

            var checkEmail = _user.GetByEmail(registrationView.Email);

            if (checkEmail != null)
            {
                ModelState.AddModelError("Email", "This email is already registered.");
                return View("SignUp", registrationView);
            }
            var newUser = new User
            {
                Name = registrationView.Name,
                Email = registrationView.Email,
                Password = registrationView.Password
            };
            _user.Add(newUser);
            _user.Save();

            TempData["Message"] = "Account created successfully. Please log in.";
            return RedirectToAction("Index");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
