using System;


namespace Services.Models
{
    public class LendingModel
    {
        public int Id { get; set; }
        public DateTime LendingDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int BookId { get; set; }
        public int ClientId { get; set; }
        public int LibraryId { get; set; }
        
    }
}