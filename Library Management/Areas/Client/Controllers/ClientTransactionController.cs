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
    public class ClientTransactionController : Controller
    {
        // GET: ClientTransactionController
        public async Task<ActionResult> Index()
        {
            List<Transactions> transactions = new List<Transactions>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44371/");
            HttpResponseMessage response = await client.GetAsync("api/transaction");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                transactions = JsonConvert.DeserializeObject<List<Transactions>>(result);
            }

            return View(transactions);
        }



        private async Task<ActionResult> GetTransaction(int id)
        {
            Transactions transactions = new Transactions();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44371/");
            HttpResponseMessage response = await client.GetAsync($"api/transaction/{id}");
            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                transactions = JsonConvert.DeserializeObject<Transactions>(results);
            }
            return View(transactions);
        }


        // GET: ClientTransactionController/Details/5
        public async Task<ActionResult> Details(int id)
        {

            return await GetTransaction(id);
        }

        // GET: ClientTransactionController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientTransactionControllerCreate
        [HttpPost]

        public async Task<ActionResult> Create(Transactions transactions)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44371/");
            var response = await client.PostAsJsonAsync<Transactions>("api/transaction", transactions);
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
            var response = await client.DeleteAsync($"api/transaction/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        // GET: ClientTransactionController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            //Books book = await GetBook(id);
            return await GetTransaction(id);
        }


        // POST: ClientTransactionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Transactions transactions)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44371/");
            HttpResponseMessage response = await client.PutAsJsonAsync<Transactions>($"api/transaction/{transactions.Id}", transactions);
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
        //    HttpResponseMessage response = await client.DeleteAsync($"api/transaction/{id}");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        // POST: ClientTransactionController/Delete/5
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
