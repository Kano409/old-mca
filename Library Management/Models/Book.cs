using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public int PageNo { get; set; }
        public string BookImage { get; set; }
        public ICollection<StudentBook> Bridge { get; set; } = new HashSet<StudentBook>();
        public ICollection<BookBorrowing> Middle { get; set; } = new HashSet<BookBorrowing>();

    }


}

