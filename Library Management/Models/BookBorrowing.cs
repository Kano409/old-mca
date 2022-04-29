using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management.Models
{
    public class BookBorrowing
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        //public int BorrowingId { get; set; }
        public Book book { get; set; }
        //public Borrowing Borrowing { get; set; }
    }
}
