using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMISAppLayer.DTOs;
using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMISAppLayer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProjectUserController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<Person> userManager;

        public ProjectUserController(ApplicationDbContext dbContext, UserManager<Person> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        // GET: ProjectUserController
        public ActionResult Index()
        {
            var Users =
                (from userRoles in dbContext.UserRoles
                 join users in dbContext.Users on userRoles.UserId equals users.Id
                 join roles in dbContext.Roles on userRoles.RoleId equals roles.Id
                 select new InsertProjectUserDTO { Id = users.Id, Email = users.Email, RoleName = roles.Name }).ToList();
            ViewBag.Users = Users;
            return View();

        }


        // GET: ProjectUserController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ProjectUserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(InsertProjectUserDTO insertProjectUserDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (insertProjectUserDTO.RoleName == "Admin")
                    {
                        var user = new Person
                        {
                            Email = insertProjectUserDTO.Email,
                            UserName = insertProjectUserDTO.Email,
                            EmailConfirmed = true,
                        };
                        var result = await userManager.CreateAsync(user, insertProjectUserDTO.Password);
                       var role= await userManager.AddToRoleAsync(user, insertProjectUserDTO.RoleName);
                    }
                    else
                    {
                        var user = new ProjectManager
                        {
                            Email = insertProjectUserDTO.Email,
                            UserName = insertProjectUserDTO.Email,
                            EmailConfirmed = true,
                        };
                        var result = await userManager.CreateAsync(user, insertProjectUserDTO.Password);
                        await userManager.AddToRoleAsync(user, insertProjectUserDTO.RoleName);
                    }
                    return RedirectToAction(nameof(Index),"Project");
                }
                return View(insertProjectUserDTO);
            }
            catch
            {
                return View(insertProjectUserDTO);
            }
        }

        // GET: ProjectUserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProjectUserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: ProjectUserController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var user = await userManager.FindByIdAsync(id);
                await userManager.DeleteAsync(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
