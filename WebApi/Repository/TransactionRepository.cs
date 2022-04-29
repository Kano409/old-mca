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
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApiDbContext _Context;
        public TransactionRepository(ApiDbContext context)
        {
            _Context = context;
        }
        public async Task<Transactions> AddTransaction(Transactions transaction)
        {
            var result = await _Context.Transactions.AddAsync(transaction);
            await _Context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Transactions> DeleteTransaction(int Id)
        {
            var result = await _Context.Transactions.Where(a => a.Id == Id).FirstOrDefaultAsync();

            if (result != null)
            {
                _Context.Transactions.Remove(result);
                await _Context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Transactions> GetTransaction(int Id)
        {
            var result = await _Context.Transactions.FirstOrDefaultAsync(a => a.Id == Id);
            await _Context.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<Transactions>> GetTransactions()
        {
            return await _Context.Transactions.ToListAsync();
        }

        public async Task<IEnumerable<Transactions>> Search(string status)
        {
            IQueryable<Transactions> query = _Context.Transactions;
            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(a => a.Status.Contains(status));
            }
            return await query.ToListAsync();
        }

        public async Task<Transactions> UpdateTransaction(Transactions transaction)
        {
            // result -> already in db
            var result = await _Context.Transactions.FirstOrDefaultAsync(a => a.Id == transaction.Id);
            if (result != null)
            {
                //result.Id = transaction.Id;
                result.Status = transaction.Status;
                _Context.SaveChanges();
                return result;
            }
            return null;
        }
    }
}
