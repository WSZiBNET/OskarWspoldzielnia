using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        public object UTF8 { get; private set; }

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
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //List<TblUsers> users = new List<TblUsers>();
            //SerializeObject
            TblUsers users = new TblUsers();

            var response = await _services.Client.GetAsync($"api/TblUsers/{id}");
            if (response.Content == null )
            {
                return NotFound();
            }

            if (response.IsSuccessStatusCode)
            {
                var loadedUsers = response.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<TblUsers>(loadedUsers);
            }
            return View(users);
        }

        // GET: UsersControler/Create
        public ActionResult Create()
        {
            return View();
        }

        class OsobaJson
        {
            public string Login { get; set; }
            public string Password { get; set; }

            public OsobaJson(string login, string password)
            {
                Login = login;
                Password = password;
            }
        }
        // POST: UsersControler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        // public async Task<ActionResult> Delete(int id, IFormCollection collection)
        public async Task<ActionResult> Create(string Login, string Password, IFormCollection collection)
        {
            OsobaJson newUser = new OsobaJson(Login, Password);

            var content = new StringContent(JsonConvert.SerializeObject(newUser));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var request = _services.Client.PostAsync("api/TblUsers", content);

            var response = request.Result.Content.ReadAsStringAsync().Result;

            return Redirect("./");
        }

        // GET: UsersControler/Edit/5
        public async  Task<ActionResult> Edit(int id)
        {
            TblUsers users = new TblUsers();

            var response = await _services.Client.GetAsync($"api/TblUsers/{id}");
            if (response.IsSuccessStatusCode)
            {
                var pobranyUser = response.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<TblUsers>(pobranyUser);
            }
            return View(users);
            
        }

        // POST: Filmy/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, DateTime addDate, string addUser, IFormCollection collection)
        {
            try
            {
                TblUsers users = new TblUsers();
                users.Id = id;
                users.Login =  collection["login"].ToString();
                users.Password = collection["password"].ToString();

                users.AddDate = addDate; /* Convert.ToDateTime(collection["AddDate"].ToString()); */
                users.AddUser = addUser; /* collection["addUser"].ToString(); */

                users.ModDate = Convert.ToDateTime(collection["modDate"].ToString());
                users.ModUser = collection["ModUser"].ToString();

                users.IsAdmin = false; // Convert.ToBoolean(collection["isAdmin"].ToString());
                users.Active = true; // Convert.ToBoolean(collection["active"].ToString());

                string jsonEditUser = JsonConvert.SerializeObject(users, Formatting.Indented);
                var content = new StringContent(jsonEditUser, Encoding.UTF8, "application/json");

                var request = await _services.Client.PutAsync($"/api/Films/{id}", content);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersControler/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            TblUsers users = new TblUsers();

            var response = await _services.Client.GetAsync($"api/TblUsers/{id}");
            if (response.Content == null)
            {
                return NotFound();
            }

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            if (response.IsSuccessStatusCode)
            {
                var loadedUsers = response.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<TblUsers>(loadedUsers);
            }

            return View(users);
        }

        // POST: UsersControler/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _services.Client.DeleteAsync($"api/TblUsers/{id}");
            }
            catch
            {
                throw new System.InvalidOperationException("Error");
            }
            return Redirect("../");
        }
    }
}
