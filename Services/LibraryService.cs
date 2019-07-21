using Data2;
using Entities;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LibraryService : ILibraryService
    {
        private readonly LibraryManagementDataContext db;

        public LibraryService()
        {
            db = new LibraryManagementDataContext();
        }

        public IEnumerable<LibraryModel> GetAll()
        {
            var result = db.Libraries.Select(x => new LibraryModel()
            {
                Id = x.Id,
                Name = x.Name,
                City = x.City,
                Address = x.Address
            });
            return result;
        }

        public IQueryable<LibraryDetailModel> GetAllLibraryDetails(int libraryId)
        {
            var libraryDetails = db.BookCopies.Where(x => x.LibraryId == libraryId).Select(x => new LibraryDetailModel()
            {
                Id = x.Id,
                LibraryId = x.LibraryId,
                LibraryName = x.Library.Name,
                BookId = x.BookId,
                BookName = x.Book.Title,
                BookCopiesNumber = x.NumberOfCopies

            });
            return libraryDetails;
        }

        public LibraryModel GetById(int id)
        {
            var dbLibrary = db.Libraries.FirstOrDefault(x => x.Id == id);
            if (dbLibrary == null)
            {
                return null;

            }
            else
            {
                var library = new LibraryModel()
                {
                    Id = dbLibrary.Id,
                    Name = dbLibrary.Name,
                    City = dbLibrary.City,
                    Address = dbLibrary.Address
                };

                return library;
            }

        }

        public bool InsertLibrary(LibraryModel library)
        {
            try
            {
                var dbLibrary = new Library()
                {
                    Name = library.Name,
                    City = library.City,
                    Address = library.Address
                };

                db.Libraries.Add(dbLibrary);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var dbLibrary = db.Libraries.FirstOrDefault(x => x.Id == id);
                db.Libraries.Remove(dbLibrary);

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateLibrary (LibraryModel library)
        {
            try
            {
                var dbLibrary = db.Libraries.FirstOrDefault(x => x.Id == library.Id);

                dbLibrary.Name = library.Name;
                dbLibrary.City = library.City;
                dbLibrary.Address = library.Address;

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }
}
