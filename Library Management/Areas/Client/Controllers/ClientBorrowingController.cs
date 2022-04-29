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
    public class ClientBorrowingController : Controller
    {
       
            // GET: ClientBookController
            public async Task<ActionResult> Index()
            {
                List<Borrowings> borrowings = new List<Borrowings>();
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44371/");
                HttpResponseMessage response = await client.GetAsync("api/borrowing");
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    borrowings = JsonConvert.DeserializeObject<List<Borrowings>>(result);
                }

                return View(borrowings);
            }



            private async Task<ActionResult> GetBorrowings(int id)
            {
                Borrowings borrowings = new Borrowings();
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44371/");
                HttpResponseMessage response = await client.GetAsync($"api/borrowing/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var results = response.Content.ReadAsStringAsync().Result;
                    borrowings = JsonConvert.DeserializeObject<Borrowings>(results);
                }
                return View(borrowings);
            }


            // GET: ClientBookController/Details/5
            public async Task<ActionResult> Details(int id)
            {
                return await GetBorrowings(id);
            }

            // GET: ClientBookController/Create
            [HttpGet]
            public ActionResult Create()
            {
                return View();
            }

            // POST: ClientBookController/Create
            [HttpPost]

            public async Task<ActionResult> Create(Borrowings borrowings)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44371/");
                var response = await client.PostAsJsonAsync<Borrowings>("api/borrowing", borrowings);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }

            // GET: ClientBookController/Edit/5
            public async Task<ActionResult> Edit(int id)
            {
                return await GetBorrowings(id);
            }


            // POST: ClientBookController/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Edit(int id, Borrowings borrowings)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44371/");
                HttpResponseMessage response = await client.PutAsJsonAsync<Borrowings>($"api/borrowing/{borrowings.Id}", borrowings);
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
                HttpResponseMessage response = await client.DeleteAsync($"api/borrowing/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }

        }
    }
