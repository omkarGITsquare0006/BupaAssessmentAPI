using BupaAssessmentAPI.Models;
using Newtonsoft.Json;

namespace BupaAssessmentAPI
{
    public class BookInformationImpl : IBook
    {
        public IEnumerable<BookAuth> GetBooks(string cat)
        {
            using StreamReader reader = new("Books.json");
            var json = reader.ReadToEnd();
            var Owner = JsonConvert.DeserializeObject<Owner>(json);
            List<BookAuth> books = null;
            switch (cat)
            {
                case "All":
                    books = Owner.BookAuth;
                    break;
                case "Child":
                    books = Owner.BookAuth.FindAll(x => x.Age < 17);
                    break;
                case "Adult":
                    books = Owner.BookAuth.FindAll(x => x.Age > 17);
                    break;
                default:
                    books = new List<BookAuth>();
                    break;
            }
            return books;
        }
    }
}
