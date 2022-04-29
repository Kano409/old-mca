
using Library_Management.Models;
using Library_Management.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management.Controllers
{
    public class BorrowingController : Controller
    {
        //public readonly ApplicationDbContext _Context;
        //public BorrowingController(ApplicationDbContext context)
        //{
        //    _Context = context;
        //}

        //// GET: BorrowingController
       
       
        //// GET: BorrowingController
        //public async Task<ActionResult> Index()
        //{
        //    return View(await _Context.Borrowings.ToListAsync());
        //}

        //// GET: BorrowingController/Details/5
        //public async Task<ActionResult> Details(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var borrower = await _Context.Borrowings.Where(a => a.Id == id).FirstOrDefaultAsync();
        //    if (borrower == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(borrower);

        //}        

        //// GET: BorrowingController/Create
        //public ActionResult Create()
        //{            
        //    return View();
        //}

        //// POST: BorrowingController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Borrowing borrow)
        //{
        //    var borro = _Context.Borrowings.Add(borrow);
        //    if (borro.Entity != null)
        //    {
        //        _Context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(borro);

        //}

        //// GET: BorrowingController/Edit/5
        //public async Task<ActionResult> Edit(int id)
        //{
        //    if (id ==null)
        //    {
        //        return NotFound();
        //    }
        //    var borrow = await _Context.Borrowings.Where(a => a.Id == id).FirstOrDefaultAsync();
        //    if (borrow == null)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View(borrow);
        //}

        //// POST: BorrowingController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, Borrowing borrow)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    _Context.Borrowings.Update(borrow);
        //    _Context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //// GET: BorrowingController/Delete/5
        //public async Task<ActionResult> Delete(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var borrow = await _Context.Borrowings.Where(a => a.Id == id).FirstOrDefaultAsync();
        //    if (borrow == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(borrow);
        //}

        //// POST: BorrowingController/Delete/5
        //[HttpPost,ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirm(Borrowing borrow)
        //{
        //    _Context.Borrowings.Remove(borrow);
        //    await _Context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
    }
}
