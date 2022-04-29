using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public int PageNo { get; set; }
        //public string BookImage { get; set; }
    }
}
