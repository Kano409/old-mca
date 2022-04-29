using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Interface
{
    public interface IBorrowingRepository
    {
        Task<IEnumerable<Borrowings>> GetBorrowings();
        Task<Borrowings> GetBorrowing(int Id);
        Task<Borrowings> AddBorrowing(Borrowings borrowing);
        Task<Borrowings> UpdateBorrowing(Borrowings borrowing);
        Task<Borrowings> DeleteBorrowing(int Id);
        Task<IEnumerable<Borrowings>> Search(string Id);
    }
}
