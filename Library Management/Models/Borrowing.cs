using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management.Models
{
    public class Borrowing
    {
        public int Id { get; set; }
        //public int BookId { get; set; }
        //public Book Book { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DueDate { get; set; }
        //public Student Student { get; set; }
        public ICollection<BookBorrowing> Middle { get; set; } = new HashSet<BookBorrowing>();

    }
}
