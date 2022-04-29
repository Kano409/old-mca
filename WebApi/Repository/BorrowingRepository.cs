using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataContext;
using WebApi.Interface;

namespace WebApi.Repository
{
    public class BorrowingRepository : IBorrowingRepository
    {
        private readonly ApiDbContext _Context;
        public BorrowingRepository(ApiDbContext context)
        {
            _Context = context;
        }
        public async Task<Borrowings> AddBorrowing(Borrowings borrowing)
        {
            var result = await _Context.Borrowings.AddAsync(borrowing);
            await _Context.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<Borrowings> DeleteBorrowing(int Id)
        {
            var result = await _Context.Borrowings.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if (result != null)
            {
                _Context.Borrowings.Remove(result);
                await _Context.SaveChangesAsync();
                return result;
            }
            return null;

        }

        public async Task<Borrowings> GetBorrowing(int Id)
        {
            return await _Context.Borrowings.Where(a => a.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Borrowings>> GetBorrowings()
        {
            return await _Context.Borrowings.ToListAsync();
        }

        public async Task<IEnumerable<Borrowings>> Search(string Id)
        {
            IQueryable<Borrowings> query = _Context.Borrowings;
            //if (!String.IsNullOrEmpty(Id.ToString()))            
            if (!string.IsNullOrEmpty(Id))                
            {
                query = query.Where(a => a.Id.ToString().Contains(Id));
            }
            return await query.ToListAsync();
        }

    

        public async Task<Borrowings> UpdateBorrowing(Borrowings borrowing)
        {
            var result = await _Context.Borrowings.Where(a => a.Id == borrowing.Id).FirstOrDefaultAsync();
            if (result != null)
            {
                
                result.ReleaseDate = borrowing.ReleaseDate;
                result.DueDate = borrowing.DueDate;
                _Context.SaveChanges();
                return result;
            }
            return null;
        }
    }
}
