using BupaAssessmentAPI.Models;

namespace BupaAssessmentAPI
{
    public interface IBook
    {
        public Task<Dictionary<string, List<string>>> GetBooks();
    }
}
