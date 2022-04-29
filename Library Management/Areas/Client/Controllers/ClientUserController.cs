using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Library_Management.Areas.Client.Controllers
{
    [Area("Client")]
    public class ClientUserController : Controller
    {
        // GET: ClientUserController
        public async Task<ActionResult> Index()
        {
            List<User> users = new List<User>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44371/");
            HttpResponseMessage response = await client.GetAsync("api/user");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<User>>(result);
            }

            return View(users);
        }



        private async Task<ActionResult> GetUser(int id)
        {
            User user = new User();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44371/");
            HttpResponseMessage response = await client.GetAsync($"api/user/{id}");
            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<User>(results);
            }
            return View(user);
        }


        // GET: ClientBookController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return await GetUser(id);
        }

        // GET: ClientBookController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientBookController/Create
        [HttpPost]

        public async Task<ActionResult> Create(User users)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44371/");
            var response = await client.PostAsJsonAsync<User>("api/user", users);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //[HttpGet]
        //public async Task<IActionResult> Delete(int id)
        //{


        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("https://localhost:44371/");
        //    HttpResponseMessage response = await client.DeleteAsync($"api/user/{id}");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}


        // GET: ClientBookController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return await GetUser(id);
        }


        // POST: ClientBookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id,User users)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44371/");
            HttpResponseMessage response = await client.PutAsJsonAsync<User>($"api/user/{users.Id}", users);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44371/");
            HttpResponseMessage response = await client.DeleteAsync($"api/user/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        
    }
}
