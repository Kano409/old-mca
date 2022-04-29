using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management.Areas.Client.ViewModel
{
    public class BookImageViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public int PageNo { get; set; }
        public IFormFile BookNameImage { get; set; }
        public string  ImageName { get; set; }
    }
}
