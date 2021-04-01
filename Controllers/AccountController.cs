using AppointmentScheduling.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentScheduling.ViewModels;
using Microsoft.AspNetCore.Identity;
using AppointmentScheduling.Models;

namespace AppointmentScheduling.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db = null;
        private readonly UserManager<ApplicationUser> _userManager = null;
        private readonly SignInManager<ApplicationUser> _signInManager = null;
        private readonly RoleManager<IdentityRole> _roleManager = null;
        public AccountController(ApplicationDbContext db, UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this._db = db;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Login() => View();



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!(ModelState.IsValid))
            {
                return View();
            }

            var userToLogin = await this._signInManager.PasswordSignInAsync(userName: loginViewModel.Email, password: loginViewModel.Password, isPersistent: loginViewModel.RememberMe, lockoutOnFailure: false);
            if((userToLogin.Succeeded))
            {
                return RedirectToAction("Index", "Appointment");
            }
            ModelState.AddModelError("", "Invalid login attempt");
            return View(loginViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            if(!(this._roleManager.RoleExistsAsync(Helper.Helper.Admin).GetAwaiter().GetResult()))
            {
                await _roleManager.CreateAsync(new IdentityRole(Helper.Helper.Admin));
                await _roleManager.CreateAsync(new IdentityRole(Helper.Helper.Doctor));
                await _roleManager.CreateAsync(new IdentityRole(Helper.Helper.Patient));   
            }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if(!(ModelState.IsValid))
            {
                return View();
            }


            var user = new ApplicationUser()
            {
               UserName = registerViewModel.Email,
               Email = registerViewModel.Email,
               Name = registerViewModel.Name
            };
            var createdUser = await this._userManager.CreateAsync(user, registerViewModel.Password); // password is hashed into the database
            if((createdUser.Succeeded))
            {
                await this._userManager.AddToRoleAsync(user, registerViewModel.RoleName);
                await this._signInManager.SignInAsync(user: user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            foreach(var erro in createdUser.Errors)
            {
                ModelState.AddModelError("", erro.Description);
            }
            return View(registerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        { 
            await this._signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        
    }
}
