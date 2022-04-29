
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
    public class TransactionController : Controller
    {
        
        //// GET: TransactionController
        //public async Task<ActionResult> Index()
        //{            
        //    return View(await _Context.Transactions.ToListAsync());
        //}

        //// GET: TransactionController/Details/5
        //public async Task<ActionResult> Details(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var trans = await _Context.Transactions.Where(a => a.Id == id).FirstOrDefaultAsync();
        //    if (trans == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(trans);
        //}

        //// GET: TransactionController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: TransactionController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Transaction transaction)
        //{
        //    var trans = _Context.Transactions.Add(transaction);
        //    if (trans.Entity != null)
        //    {
        //        _Context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(trans);                
         
        //}

        //// GET: TransactionController/Edit/5
        //public async Task<ActionResult> Edit(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var trans = await _Context.Transactions.Where(a => a.Id == id).FirstOrDefaultAsync();
        //    if (trans == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(trans);
        //}

        //// POST: TransactionController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id,Transaction transaction)
        //{
        //    _Context.Transactions.Update(transaction);
        //    _Context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //// GET: TransactionController/Delete/5
       
        //public async Task<ActionResult> Delete(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var trans = await _Context.Transactions.Where(a => a.Id == id).FirstOrDefaultAsync();
        //    if (trans == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(trans);
        //}

        //// POST: TransactionController/Delete/5
        //[HttpPost,ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirm(Transaction transaction)
        //{            
        //    _Context.Transactions.Remove(transaction);
        //    await _Context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
    }
}
