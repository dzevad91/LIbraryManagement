using Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{

    public interface IBookService
    {
        bool UpdateBook(int id ,BookModel book);
        bool InsertBook(BookModel book);
        IEnumerable<BookModel> GetAll();
        BookModel GetById(int id);
        bool Delete(int id);
    }
    
}
