using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data2
{
    public class LibraryManagementDataContext : DbContext
    {
        public LibraryManagementDataContext() : base("LocalDb")
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Lending> Lendings { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}

