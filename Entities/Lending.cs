using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Lending
    {
        [Key]
        public int Id { get; set; }
        public DateTime LendingDate { get; set; }
        public DateTime ReturnDate { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
       
        public virtual Book Book { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        
        public virtual Client Client { get; set; }

        [ForeignKey("Library")]
        public int LibraryId { get; set; }

        public virtual Library Library { get; set; }
    }
}