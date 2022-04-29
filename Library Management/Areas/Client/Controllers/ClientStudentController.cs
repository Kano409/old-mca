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
    public class ClientStudentController : Controller
    {
        

        // GET: ClientStudentController
        public async Task<ActionResult> Index()
        {
            List<Student> students = new List<Student>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44371/");
            HttpResponseMessage response = await client.GetAsync("api/student");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                students = JsonConvert.DeserializeObject<List<Student>>(result);
            }

            return View(students);
        }



        private async Task<ActionResult> GetStudent(int id)
        {
            Student student = new Student();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44371/");
            HttpResponseMessage response = await client.GetAsync($"api/student/{id}");
            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                student = JsonConvert.DeserializeObject<Student>(results);
            }
            return View(student);
        }


        // GET: ClientStudentController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return await GetStudent(id);
        }

        // GET: ClientBookController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientStudentController/Create
        [HttpPost]

        public async Task<ActionResult> Create(Student students)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44371/");
            var response = await client.PostAsJsonAsync<Student>("api/student", students);
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


        // GET: ClientStudentController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return await GetStudent(id);
        }


        // POST: ClientBookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Student students)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44371/");
            HttpResponseMessage response = await client.PutAsJsonAsync<Student>($"api/student/{students.Id}", students);
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
            HttpResponseMessage response = await client.DeleteAsync($"api/student/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
