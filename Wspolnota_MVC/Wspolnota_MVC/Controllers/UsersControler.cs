using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIWspolnota.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Wspolnota_MVC.Services;

namespace Wspolnota_MVC.Controllers
{
    public class UsersControler : Controller
    {
        private IAPIService _services;

        public UsersControler(IAPIService service)
        {
            _services = service;
        }
        
        // GET: UsersControler
        public async Task<ActionResult> Index()
        {
            List<TblUsers> users = new List<TblUsers>();

            var response = await _services.Client.GetAsync("api/TblUsers");
            if (response.IsSuccessStatusCode)
            {
                var loadedUsers = response.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject <List<TblUsers>> (loadedUsers);
            }
            return View(users);
        }

        // GET: UsersControler/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersControler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersControler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: UsersControler/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersControler/Edit/5
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

        // GET: UsersControler/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersControler/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
