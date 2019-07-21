using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public int YearOfIssue { get; set; }
        public int NumberOfPages { get; set; }

        [ForeignKey("Publisher")]
        public int PublisherId { get; set; }

        public virtual Publisher Publisher { get; set; }

    }
}