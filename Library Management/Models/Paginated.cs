using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management.Models
{
    public class Paginated<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPage { get; set; }
        public Paginated(List<T> item, int count, int pageIndex, int pageSize)
        {

            PageIndex = pageIndex;
            TotalPage = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(item);
        }
        public bool PreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }

        }
        public bool NextsPage
        {
            get
            {
                return (PageIndex < TotalPage);
            }

        }
        public static async Task<Paginated<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var result = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new Paginated<T>(result, count, pageIndex, pageSize);

        }

    }
}

