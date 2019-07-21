namespace Services.Models
{
    public class BookCopyModel
    {
        public int Id { get; set; }
        public int NumberOfCopies { get; set; }
        public int BookId { get; set; }       
        public int LibraryId { get; set; }
    }
}