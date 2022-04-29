using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class Transactions
    {
        public int Id { get; set; }
        //public int BorrowingId { get; set; }
        //public int StudentId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        //public Borrowing Borrowing { get; set; }
    }
}
