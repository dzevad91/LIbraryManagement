using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Services.Models
{
    public class LibraryDetailModel
    {
        public int Id { get; set; }
        public int LibraryId { get; set; }
        public string LibraryName { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int BookCopiesNumber { get; set; }
    }
}