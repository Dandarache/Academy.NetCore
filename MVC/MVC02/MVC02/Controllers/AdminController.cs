using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mvc02.Services;

namespace Mvc02.Controllers
{
    //[Authorize(Roles = "SuperAdmin,AndraAdmins")]
    public class AdminController : Controller
    {
        private readonly AuthService _authService;

        public AdminController(AuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string userEmail, string role)
        {
            // 0. Kolla om det finns några valideringsfel.
            if (!ModelState.IsValid)
            {
                return View("Index"); // return View();
            }

            // 1. Kolla om användaren finns.
            var userExist = await _authService.UserExist(userEmail);
            if (!userExist)
            {
                ModelState.AddModelError("UserDontExist", $"The user {userEmail} doesn't exist.");
                return View();
            }

            // 2. Kolla om användaren redan finns kopplad till rollen.
            var userAlredyInRole = await _authService.IsInRoleAsync(userEmail, role);
            if (userAlredyInRole)
            {
                ModelState.AddModelError("UserAlreadyInRole", "The user is already in the role.");
                return View();
            }

            // 3. Finns den aktuella rollen redan?
            var roleExist = await _authService.RoleExistsAsync(role);
            if (!roleExist)
            {
                await _authService.CreateRoleAsync(role);
            }

            // 4. Koppla användaren till rollen.
            await _authService.AddToRoleAsync(userEmail, role);

            // Visa tack-sidan.
            return View("UserAdded", userEmail);












            //if (!ModelState.IsValid)
            //    return View("Index");

            //bool userExist = await _authService.UserExist(addrole.Email);

            //if (!userExist)
            //{
            //    ModelState.AddModelError("UserDontExist", $"User with email {addrole.Email} doesn't exist");
            //    return View("Index");
            //}

            //bool alreadyInRole = await _auth.IsInRoleAsync(addrole.Email, addrole.RoleName);

            //if (alreadyInRole)
            //{
            //    ModelState.AddModelError("UserAlreadyInrole", $"{addrole.Email} already belongs to role {addrole.RoleName}");
            //    return View("Index");
            //}

            //bool roleExist = await _auth.RoleExistsAsync(addrole.RoleName);

            //if (!roleExist)
            //    await _auth.CreateRoleAsync(addrole.RoleName); // todo: hantera oväntat fel

            //await _auth.AddToRoleAsync(addrole.Email, addrole.RoleName);

            //return View("SuccessAddRole", addrole);

        }

    }
}