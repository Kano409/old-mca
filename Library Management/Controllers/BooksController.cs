
using Library_Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management.Controllers
{
    public class BooksController : Controller
    {
        //public readonly ApplicationDbContext _Context;
        //public BooksController(ApplicationDbContext context)
        //{
        //    _Context = context;
        //}
        //// GET: BooksController
        //public async Task<ActionResult> Index()
        //{
        //    return View(await _Context.Books.ToListAsync());
        //}

        //// GET: BooksController/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var books = _Context.Books.Where(x => x.Id == id).FirstOrDefault();
          
        //    return View(books);
        //}

        //// GET: BooksController/Create
        //public ActionResult Create()
        //{
        //    // no pass data
        //    return View();
        //}

        //// POST: BooksController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Book model)
        //{
        //    var book = _Context.Books.Add(model);
        //    if (book.Entity != null)
        //    {
        //        _Context.SaveChanges();
        //        return RedirectToAction("Index");

        //    }
        //    return View(book);
            
        //}

        //// GET: BooksController/Edit/5
        //[HttpGet]
        //public async Task<ActionResult> Edit(int id)
        //{
        //    var books = await _Context.Books.Where(a => a.Id == id).FirstOrDefaultAsync();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(books);
            
        //}

        //// POST: BooksController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id,Book model)
        //{
        //    _Context.Books.Update(model);
        //    _Context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //// GET: BooksController/Delete/5
        //[HttpGet]
        //public async Task<ActionResult> Delete(int id)
        //{
           
        //    var books = await _Context.Books.Where(a => a.Id == id).FirstOrDefaultAsync();
        //    return View(books);

           
        //}

        //// POST: BooksController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Delete(Book book)
        //{
            
        //     _Context.Books.Remove(book);
        //    await _Context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
    }
}
