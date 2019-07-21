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
    public class LendingService : ILendingService
    {
        private readonly LibraryManagementDataContext db;

        public LendingService()
        {
            db = new LibraryManagementDataContext();
        }

        public IEnumerable<LendingModel> GetAll()
        {
            var result = db.Lendings.Select(x => new LendingModel()
            {
                Id = x.Id,
                LendingDate = x.LendingDate,
                ReturnDate = x.ReturnDate,
                BookId = x.BookId,
                ClientId = x.ClientId,
                LibraryId = x.LibraryId
            });
            return result;
        }

        public LendingModel GetById(int id)
        {
            var dbLending = db.Lendings.FirstOrDefault(x => x.Id == id);
            if (dbLending == null)
            {
                return null;

            }
            else
            {
                var lending = new LendingModel()
                {
                    Id = dbLending.Id,
                    LendingDate = dbLending.LendingDate,
                    ReturnDate = dbLending.ReturnDate,
                    BookId = dbLending.BookId,
                    ClientId = dbLending.ClientId,
                    LibraryId = dbLending.LibraryId
                };

                return lending;
            }

        }

        public bool InsertLending(LendingModel lending)
        {
            try
            {
                var dbLending = new Lending()
                {
                    LendingDate = lending.LendingDate,
                    ReturnDate = lending.ReturnDate,
                    BookId = lending.BookId,
                    ClientId = lending.ClientId,
                    LibraryId = lending.LibraryId
                };

                db.Lendings.Add(dbLending);

                var bookCopy = db.BookCopies.FirstOrDefault(
                x => x.BookId == lending.BookId && 
                x.LibraryId ==lending.LibraryId);

                bookCopy.NumberOfCopies = bookCopy.NumberOfCopies - 1;

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public bool UpdateLending ( int id , LendingModel lending)
        {
            
            if(lending.ReturnDate == null)
            {
                try
                {
                    var dbLending = db.Lendings.FirstOrDefault(x => x.Id == id);

                    dbLending.ReturnDate = lending.ReturnDate;

                    var bookCopy = db.BookCopies.FirstOrDefault(
                    x => x.BookId == lending.BookId &&
                    x.LibraryId == lending.LibraryId);

                    bookCopy.NumberOfCopies = bookCopy.NumberOfCopies + 1;

                    db.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return false;

        }

    }
}
