using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Interface
{
    public interface IBookRepository
    {
        Task<IEnumerable<Books>> GetBooks();
        Task<Books> GetBook(int Id);
        Task<Books> AddBook(Books book);
        Task<Books> UpdateBook(Books book);
        Task<Books> DeleteBook(int Id);
        Task<IEnumerable<Books>> Search(string Name);
    }
}
