using Library_Management.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management.ViewModels
{
    public class BorrowBookViewModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        //public string BookTitle { get; set; }
        //public IList<SelectListItem> BookName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
