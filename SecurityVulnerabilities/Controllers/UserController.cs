using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityVulnerabilities.Models;

namespace SecurityVulnerabilities.Controllers
{
    public class UserController : Controller
    {
        private List<User> allUsers;

        public UserController()
        {
            allUsers = new List<User>();
            var user = new User();
            user.username = "neko";
            user.password = "nekiiic";
            allUsers.Add(user);

            user.username = "medi";
            user.password = "sifraaa123";
            allUsers.Add(user);

            user.username = "john doe";
            user.password = "password123";
            allUsers.Add(user);

        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            User userInfo = new User();
            userInfo.username = "medii";
            userInfo.password = "nekiPassword123";
            return View("Index", userInfo);
        }

        // POST: User/Login
        [HttpPost]
        public ActionResult Login(IFormCollection data)
        {
            var username = data.Select(x => x.Value).Where(y => y =="username").FirstOrDefault();
            var password = data.Select(x => x.Value).Where(y => y == "password").FirstOrDefault();

            bool doesUserExists = allUsers.Any(x => x.username == username && x.password == password);

            if (doesUserExists)
            {
                var user = allUsers.Find(x => x.username == username && x.password == password);
                return View("Index", user);
            }
            else
                return View("~/Views/Shared/Error.cshtml");
          
           
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}