﻿using IdentityExample.Data;
using IdentityExample.Models;
using IdentityExample.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IdentityExample.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly DataContext _context;

        public AccountController(UserManager<User> manager, SignInManager<User> signInManager, DataContext context)
        {
            _userManager = manager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            var employees = await _context.Employees.ToListAsync();
            var employeeDropItems = employees.Select(x => new { Id = x.Id, Name = $"{x.FirstName} {x.MiddleName} {x.LastName}" });
            var dropEmployee = new SelectList(employeeDropItems, "Id", "Name");

            var model = new SignUpViewModel();
            model.EmployeeDropDown = dropEmployee;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    EmployeeId = model.EmployeeId,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            /*
                If model is not valid again pass employee drop down menu items.
             */
            var employees = await _context.Employees.ToListAsync();
            var employeeDropItems = employees.Select(x => new { Id = x.Id, Name = $"{x.FirstName} {x.MiddleName} {x.LastName}" });
            var dropEmployee = new SelectList(employeeDropItems, "Id", "Name");
            model.EmployeeDropDown = dropEmployee;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GetEmployeeEmail(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return Json(new { success = false, email = "" });

            return Json(new { success = true, email = employee.Email });
        }
    }
}
