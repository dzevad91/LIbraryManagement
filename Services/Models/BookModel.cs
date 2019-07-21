namespace Services.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearOfIssue { get; set; }
        public int NumberOfPages { get; set; }
        public int PublisherId { get; set; }

    }
}