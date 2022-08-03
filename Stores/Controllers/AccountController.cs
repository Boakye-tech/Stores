using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Stores.Models;
using Stores.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Stores.App_Data;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stores.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ApplicationDbContext _context;


        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext appDb)
        {
            _context = appDb;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        // GET: /<controller>/
        [AllowAnonymous]
        public IActionResult Register()
        {
            List<Department> departmentList = _context.Departments.ToList();
            List<Staff> StaffList = _context.Staff.ToList();

            RegisterViewModel registerView = new RegisterViewModel();

            registerView.DepartmentDropDown = departmentList.Select(d => new SelectListItem { Text = d.DepartmentName, Value = d.DepartmentCode.ToString() });
            registerView.StaffDropDown = StaffList.Select(s => new SelectListItem { Text = s.Firstname+" "+s.Middlename+" "+s.Surname, Value = s.StaffIdentificationNumber});

            return View(registerView);
            //return View();
        }

        // POST: /<controller>/
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            //RegisterViewModel registerView = new RegisterViewModel();
            //return View(registerView);
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = viewModel.Email , Email = viewModel.Email, PhoneNumber = viewModel.PhoneNumber};
                var result = await userManager.CreateAsync(user, viewModel.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser appUser = new IdentityUser();
                 
                List<IdentityUser> appUserList = _context.AppUsers.ToList();

                appUser = appUserList.ToList().Find(a => a.UserName == model.UserName);

                var User = await userManager.FindByEmailAsync(appUser.Email);
                var result = await signInManager.PasswordSignInAsync(
                    User.UserName,model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }


    }
}
