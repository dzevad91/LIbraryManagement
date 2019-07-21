using Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{

    public interface IBookCopyService
    {
        IEnumerable<BookCopyModel> GetAllByLibraryId(int libraryId);
        bool UpdateBookCopy(int id ,BookCopyModel bookCopy);
        bool InsertBookCopy(BookCopyModel bookCopy);
        IEnumerable<BookCopyModel> GetAll();
        BookCopyModel GetById(int id);
        bool Delete(int id);
    }
    
}
