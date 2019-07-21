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
    public class BookService : IBookService
    {
        private readonly LibraryManagementDataContext db;

        public BookService()
        {
            db = new LibraryManagementDataContext();
        }

        public IEnumerable<BookModel> GetAll()
        {
            var result = db.Books.Select(x => new BookModel()
            {
                Id = x.Id,
                Title = x.Title,
                NumberOfPages = x.NumberOfPages,
                YearOfIssue = x.YearOfIssue,
                PublisherId = x.PublisherId
            });
            return result;
        }

        public BookModel GetById(int id)
        {
            var dbBook = db.Books.FirstOrDefault(x => x.Id == id);
            if (dbBook == null)
            {
                return null;

            }
            else
            {
                var book = new BookModel()
                {
                    Id = dbBook.Id,
                    Title = dbBook.Title,
                    YearOfIssue = dbBook.YearOfIssue,
                    NumberOfPages = dbBook.NumberOfPages,
                    PublisherId = dbBook.PublisherId
                };

                return book;
            }

        }

        public bool InsertBook(BookModel book)
        {
            try
            {
                var dbBook = new Book()
                {
                    Title = book.Title,
                    YearOfIssue = book.YearOfIssue,
                    NumberOfPages = book.NumberOfPages,
                    PublisherId = book.PublisherId
                };

                db.Books.Add(dbBook);
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
                var dbBook = db.Books.FirstOrDefault(x => x.Id == id);
                db.Books.Remove(dbBook);

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateBook ( int id , BookModel book)
        {
            try
            {
                var dbBook = db.Books.FirstOrDefault(x => x.Id == id);

                dbBook.Title = book.Title;
                dbBook.YearOfIssue = book.YearOfIssue;
                dbBook.NumberOfPages = book.NumberOfPages;
                dbBook.PublisherId = book.PublisherId;

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
