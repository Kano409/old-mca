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
    public class BookRepository : IBookRepository
    {
        private readonly ApiDbContext _Context;
        public BookRepository(ApiDbContext context)
        {
            _Context = context;
        }
        public async Task<Books> AddBook(Books book)
        {
            var result = await _Context.Books.AddAsync(book);
            await _Context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Books> DeleteBook(int Id)
        {
            var result = await _Context.Books.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if (result != null)
            {
                _Context.Books.Remove(result);
                await _Context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task <Books> GetBook(int Id)
        {
            var result = await _Context.Books.Where(a => a.Id == Id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<Books>> GetBooks()
        {
            return await _Context.Books.ToListAsync();
        }

        public async Task<IEnumerable<Books>> Search(string BookName)
        {
            IQueryable<Books> query = _Context.Books;
            if (!string.IsNullOrEmpty(BookName))
            {
                query = query.Where(a => a.BookName.Contains(BookName));
            }
            return await query.ToListAsync();
        }

        public async Task<Books> UpdateBook(Books book)
        {
            var result = await _Context.Books.Where(a => a.Id == book.Id).FirstOrDefaultAsync();
            if (result != null)
            {              
                result.Title = book.Title;
                result.BookName = book.BookName;
                result.Author = book.Author;
                result.Publisher = book.Publisher;
                result.PublishDate = book.PublishDate;
                result.PageNo = book.PageNo;
                _Context.SaveChanges();
                return result;
            }
            return null;
        }
    }
}
