using Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{

    public interface ILibraryService
    {
        bool UpdateLibrary(LibraryModel library);
        bool InsertLibrary(LibraryModel library);
        IEnumerable<LibraryModel> GetAll();
        IQueryable<LibraryDetailModel> GetAllLibraryDetails(int libraryId);
        LibraryModel GetById(int id);
        bool Delete(int id);
    }
    
}
