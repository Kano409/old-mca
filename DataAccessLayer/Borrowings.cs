using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class Borrowings
    {
        public int Id { get; set; }
        //public int BookId { get; set; }
        //public Book Book { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DueDate { get; set; }
        //public Student Student { get; set; }
    }
}
