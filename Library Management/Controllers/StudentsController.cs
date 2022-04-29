
using Library_Management.Models;
using Library_Management.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management.Controllers
{
    public class StudentsController : Controller
    {

       // public readonly ApplicationDbContext _Context;
       // private readonly IWebHostEnvironment _WebHostEnvironment;
       // public StudentsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
       // {
       //     _Context = context;
       //     _WebHostEnvironment = webHostEnvironment;
       // }
        
       // // GET: StudentsController
       // public async Task<IActionResult> Index(int pageNumber = 1)
       // {
       //     return View(await Paginated<Student>.CreateAsync(_Context.Students, pageNumber, 2));
       // }
       //// GET: StudentsController/Details/5
       // public async Task<ActionResult> Details(int? id)
       // {
       //     if (id == null)
       //     {
       //         return NotFound();
       //         // return View("NotFound");
       //     }

       //     var student =  await _Context.Students.Include(x => x.Bridge).ThenInclude(y => y.book).FirstOrDefaultAsync(m => m.Id == id);
       //     if (student == null)
       //     {
       //         return NotFound();
       //         // return View("NotFound",id);               
       //     }

       //     return View(student);

       // }

       // // GET: StudentsController/Create
       // public IActionResult Create()
       // {
       //     var booksName =  _Context.Books.Select(x => new SelectListItem()
       //     {
       //         Text = x.BookName,
       //         Value =  x.Id.ToString()
       //     }).ToList();
            
       //     StudentBookViewModel vm = new StudentBookViewModel();
       //     vm.BookName = booksName;
            
       //     return View(vm);            
            
       // }

        
       // // POST: StudentsController/Create
       // [HttpPost]
       // [ValidateAntiForgeryToken]
       // public ActionResult Create(StudentBookViewModel vm)
       // {
       //     var student = new Student
       //     {
       //         FirstName = vm.FirstName,
       //         LastName = vm.LastName,
       //         Age = vm.Age,
       //         MobileNo = vm.MobileNo,
       //         Email = vm.Email,
       //         Password = vm.Password
                
       //     };
       //     var selectedBookName = vm.BookName.Where(x => x.Selected).Select(y => y.Value).ToList();
       //     foreach (var item in selectedBookName)
       //     {
       //         student.Bridge.Add(new StudentBook()
       //         {
       //             // using Student, StudentBook n automatically filled
       //             BookId = int.Parse(item)

       //         });
       //     }
       //     string fileName = null;
       //     if (vm.BookNameImage != null)
       //     {
       //         string uploadDir = Path.Combine(_WebHostEnvironment.WebRootPath, "Images");
       //         fileName = Guid.NewGuid().ToString() + "-" + vm.BookNameImage.FileName;
       //         string filePath = Path.Combine(uploadDir, fileName);
       //         using (var fileStream = new FileStream(filePath, FileMode.Create))
       //         {
       //             vm.BookNameImage.CopyTo(fileStream);
       //             student.BookImage = fileName;
       //         }
                
       //     }
       //     _Context.Students.Add(student);
       //     _Context.SaveChanges();
       //     return RedirectToAction("Index");          
            
            
       // }

       // // GET: StudentsController/Edit/5
       // public async Task<ActionResult> Edit(int? id)
       // {
       //     var bookName = await _Context.Students.Include(x => x.Bridge).Where(y => y.Id == id).FirstOrDefaultAsync();
       //     if (id == null)
       //     {
       //         return NotFound();
       //     }
       //     // already checked
       //     var selectedIds = bookName.Bridge.Select(x => x.BookId).ToList();
       //     // add new
       //     var items = _Context.Books.Select(x => new SelectListItem()
       //     {
       //         Text = x.BookName,
       //         Value = x.Id.ToString(),
       //         Selected = selectedIds.Contains(x.Id)
       //     }).ToList();
       //     StudentBookViewModel vm = new StudentBookViewModel();
       //     // pass edit 
       //     vm.FirstName = bookName.FirstName;
       //     vm.LastName = bookName.LastName;
       //     vm.Age = bookName.Age;
       //     vm.MobileNo = bookName.MobileNo;
       //     vm.Email = bookName.Email;
       //     vm.Password = bookName.Password;
       //     vm.BookName = items;
       //     if (bookName == null)
       //     {
       //         return NotFound();
       //     }
       //     return View(vm);
            
       // }

       // // POST: StudentsController/Edit/5
       // [HttpPost]
       // [ValidateAntiForgeryToken]
       // public ActionResult Edit(StudentBookViewModel vm)
       // {
       //     // retrieve existing student
       //     var student = _Context.Students.Find(vm.Id);
       //     student.FirstName = vm.FirstName;
       //     student.LastName = vm.LastName;
       //     student.Age = vm.Age;
       //     student.MobileNo = vm.MobileNo;
       //     student.Email = vm.Email;
       //     student.Password = vm.Password;


       //     // update entry from middle table -> remove existing entry
       //     // toRemove entry remove from table
       //     _Context.Students.Update(student);
       //     _Context.SaveChanges();
       //     return RedirectToAction("Index");
            
            
       // }

       // // GET: StudentsController/Delete/5
       // public async Task<ActionResult> Delete(int? id)
       // {
       //     if (id == null)
       //     {
       //         return NotFound();
       //     }

       //     var student = await _Context.Students
       //         .FirstOrDefaultAsync(m => m.Id == id);
       //     if (student == null)
       //     {
       //         return NotFound();
       //     }

       //     return View(student);
       // }

       // // POST: StudentsController/Delete/5
       // [HttpPost]
       // [ValidateAntiForgeryToken]
       // public async Task<ActionResult> Delete(StudentBookViewModel vm)
       // {
       //     var student = await _Context.Students.FindAsync(vm.Id);
       //     _Context.Students.Remove(student);
       //     await _Context.SaveChangesAsync();
       //     return RedirectToAction(nameof(Index));
       // }
       // private bool StudentExists(int id)
       // {
       //     return _Context.Students.Any(e => e.Id == id);
       // }
    }
}
