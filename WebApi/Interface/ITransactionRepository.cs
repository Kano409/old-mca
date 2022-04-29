using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Interface
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transactions>> GetTransactions();
        Task<Transactions> GetTransaction(int Id);
        Task<Transactions> AddTransaction(Transactions transaction);
        Task<Transactions> UpdateTransaction(Transactions transaction);
        Task<Transactions> DeleteTransaction(int Id);
        Task<IEnumerable<Transactions>> Search(string Name);
    }
}
