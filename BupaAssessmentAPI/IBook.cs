using BupaAssessmentAPI.Models;

namespace BupaAssessmentAPI
{
    public interface IBook
    {
        public IEnumerable<BookAuth> GetBooks(string BookCategory);
    }
}
