using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        //public int BorrowingId { get; set; }
        //public int StudentId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        //public Borrowing Borrowing { get; set; }
    }
}
