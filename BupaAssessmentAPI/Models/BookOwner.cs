namespace BupaAssessmentAPI.Models
{
    public class BookAuth
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Book> Books { get; set; }
    }
    public class Owner
    {
        public List<BookAuth> BookAuth { get; set; }
    }
}
