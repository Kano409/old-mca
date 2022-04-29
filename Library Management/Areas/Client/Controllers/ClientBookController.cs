using DataAccessLayer;
using Library_Management.Areas.Client.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Library_Management.Areas.Client.Controllers
{
    [Area("Client")]
    public class ClientBookController : Controller
    {
        //private readonly IWebHostEnvironment _WebHostEnvironment;
        //public ClientBookController(IWebHostEnvironment webHostEnvironment)
        //{
        //    _WebHostEnvironment = webHostEnvironment;
        //}

        // GET: ClientUserController
        public async Task<ActionResult> Index()
        {
            List<Books> books = new List<Books>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44371/");
            HttpResponseMessage response = await client.GetAsync("api/book");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                books = JsonConvert.DeserializeObject<List<Books>>(result);
            }
            return View(books);
        }


        private async Task<ActionResult> GetBook(int id)
        {
            Books books = new Books();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44371/");
            HttpResponseMessage response = await client.GetAsync($"api/book/{id}");
            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                books = JsonConvert.DeserializeObject<Books>(results);
            }
            return View(books);
        }


        // GET: ClientBookController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return await GetBook(id);
        }

        // GET: ClientBookController/Create
        [HttpGet]
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: ClientBookController/Create

        [HttpPost]

        public async Task<ActionResult> Create(Books books)
        {
        //    var book = new Books
        //    {
        //        Title = vm.Title,
        //        BookName = vm.BookName,
        //        Author = vm.Author,
        //        Publisher = vm.Publisher,
        //        PublishDate = vm.PublishDate,
        //        PageNo = vm.PageNo     
        //    };
        //    string fileName = null;
        //    if (vm.BookNameImage != null)
        //    {
        //        string uploadDir = Path.Combine(_WebHostEnvironment.WebRootPath, "Images");
        //        fileName = Guid.NewGuid().ToString() + "-" + vm.BookNameImage.FileName;
        //        string filePath = Path.Combine(uploadDir, fileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            vm.BookNameImage.CopyTo(fileStream);
        //        }
        //    }
        //    vm.ImageName = fileName;
        //    vm.BookNameImage = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44371/");
            var response = await client.PostAsJsonAsync<Books>("api/book", books);
          
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        


        // GET: ClientBookController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return await GetBook(id);
        }


        // POST: ClientBookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Books books)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44371/");
            HttpResponseMessage response = await client.PutAsJsonAsync<Books>($"api/book/{books.Id}", books);
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
            HttpResponseMessage response = await client.DeleteAsync($"api/book/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
