using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class BookCopy
    {
        [Key]
        public int Id { get; set; }
        public int NumberOfCopies { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }       
        
        public virtual Book Book { get; set; }

        [ForeignKey("Library")]
        public int LibraryId { get; set; }
        
        public virtual Library Library { get; set; }
    }
}