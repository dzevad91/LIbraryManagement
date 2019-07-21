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
    public class BookCopyService : IBookCopyService
    {
        private readonly LibraryManagementDataContext db;

        public BookCopyService()
        {
            db = new LibraryManagementDataContext();
        }

        public IEnumerable<BookCopyModel> GetAll()
        {
            var result = db.BookCopies.Select(x => new BookCopyModel()
            {
                Id = x.Id,
                NumberOfCopies = x.NumberOfCopies,
                BookId = x.BookId,
                LibraryId = x.LibraryId
            });
            return result;
        }

        public IEnumerable<BookCopyModel> GetAllByLibraryId(int libraryId)
        {
            var result = db.BookCopies.Where(x => x.LibraryId == libraryId).Select(x => new BookCopyModel()
            {
                Id = x.Id,
                NumberOfCopies = x.NumberOfCopies,
                BookId = x.BookId,
                LibraryId = x.LibraryId
            });
            return result;
        }

        public BookCopyModel GetById(int id)
        {
            var dbBookCopy = db.BookCopies.FirstOrDefault(x => x.Id == id);
            if (dbBookCopy == null)
            {
                return null;

            }
            else
            {
                var bookCopy = new BookCopyModel()
                {
                    Id = dbBookCopy.Id,
                    NumberOfCopies = dbBookCopy.NumberOfCopies,
                    BookId = dbBookCopy.BookId,
                    LibraryId = dbBookCopy.LibraryId
                };

                return bookCopy;
            }

        }

        public bool InsertBookCopy(BookCopyModel bookCopy)
        {
            try
            {
                var dbBookCopy = new BookCopy()
                {
                    Id = bookCopy.Id,
                    NumberOfCopies = bookCopy.NumberOfCopies,
                    BookId = bookCopy.BookId,
                    LibraryId = bookCopy.LibraryId
                };

                db.BookCopies.Add(dbBookCopy);
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
                var dbBookCopy = db.BookCopies.FirstOrDefault(x => x.Id == id);
                db.BookCopies.Remove(dbBookCopy);

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateBookCopy ( int id , BookCopyModel bookCopy)
        {
            try
            {
                var dbBookCopy = db.BookCopies.FirstOrDefault(x => x.Id == id);

                dbBookCopy.NumberOfCopies = bookCopy.NumberOfCopies;

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
