
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
    public class UsersController : Controller
    {

        //    public readonly ApplicationDbContext _Context;
        //    private readonly IWebHostEnvironment _WebHostEnvironment;
        //    public UsersController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        //    {
        //        _Context = context;
        //        _WebHostEnvironment = webHostEnvironment;
        //    }

        //    // GET: UsersController
        //    public async Task<IActionResult> Index()
        //    {
        //        return View(await _Context.Users.ToListAsync());
        //    }

        //    // GET: UsersController/Details/5
        //    public ActionResult Details(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }
        //        var user = _Context.Users.Where(a => a.Id == id).FirstOrDefault();
        //        if (user == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(user);
        //    }

        //    // GET: UsersController/Create
        //    public ActionResult Create()
        //    {           


        //        return View();
        //    }

        //    // POST: UsersController/Create
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Create(UserImage vm)
        //    {
        //        var user = new User
        //        {
        //            FirstName = vm.FirstName,
        //            LastName = vm.LastName,
        //            Age = vm.Age,
        //            MobileNo = vm.MobileNo,
        //            Email = vm.Email,
        //            Password = vm.Password

        //        };
        //        string fileName = null;
        //        if (vm.UserNameImage != null)
        //        {
        //            string uploadDir = Path.Combine(_WebHostEnvironment.WebRootPath, "Images");
        //            fileName = Guid.NewGuid().ToString() + "-" + vm.UserNameImage.FileName;
        //            string filePath = Path.Combine(uploadDir, fileName);
        //            using (var fileStream = new FileStream(filePath, FileMode.Create))
        //            {
        //                vm.UserNameImage.CopyTo(fileStream);
        //                user.UserImage = fileName;
        //            }

        //        }
        //        _Context.Users.Add(user);
        //        _Context.SaveChanges();
        //        return RedirectToAction("Index");



        //        //var userx = _Context.Users.Add(user);
        //        //if(userx.Entity != null)
        //        //{
        //        //    _Context.SaveChanges();
        //        //    return RedirectToAction("Index");
        //        //}
        //        //return View(userx);
        //    }

        //    // GET: UsersController/Edit/5
        //    public async Task<ActionResult> Edit(int id)
        //    {
        //        var user = await _Context.Users.Where(a => a.Id == id).FirstOrDefaultAsync();
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }
        //        UserImage vm = new UserImage();
        //        vm.FirstName = user.FirstName;
        //        vm.LastName = user.LastName;
        //        vm.Age = user.Age;
        //        vm.MobileNo = user.MobileNo;
        //        vm.Email = user.Email;
        //        vm.Password = user.Password;
        //        return View(vm);
        //    }

        //    // POST: UsersController/Edit/5
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit(int id, UserImage vm)
        //    {
        //        var user = _Context.Users.Find(vm.Id);
        //        user.FirstName = vm.FirstName;
        //        user.LastName = vm.LastName;
        //        user.Age = vm.Age;
        //        user.MobileNo = vm.MobileNo;
        //        user.Email = vm.Email;
        //        user.Password = vm.Password;
        //        _Context.Users.Update(user);
        //        _Context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    // GET: UsersController/Delete/5
        //    public async Task<IActionResult> Delete(int id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var user = await _Context.Users.FirstOrDefaultAsync(m => m.Id == id);
        //        if (user == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(user);

        //    }

        //    // POST: UsersController/Delete/5
        //    [HttpPost,ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirm(UserImage vm)
        //    {
        //        var user = await _Context.Users.FindAsync(vm.Id);
        //        _Context.Users.Remove(user);
        //        await _Context.SaveChangesAsync();
        //        return RedirectToAction("Index");

        //    }
        //}
    }
}
