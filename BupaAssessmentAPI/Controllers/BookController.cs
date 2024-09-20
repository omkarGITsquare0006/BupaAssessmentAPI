using System.Linq;
using BupaAssessmentAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BupaAssessmentAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBook _bookService;
        public BookController(ILogger<BookController> logger,IBook bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet(Name = "GetAllBooks")]
        public IEnumerable<BookAuth> GetAllBooks()
        {
            var booksOwner = _bookService.GetBooks("All");
            if (booksOwner == null) { return new List<BookAuth>(); }
            return booksOwner;
        }

        [HttpGet]
        [Route("GetChildBooks")]
        public IEnumerable<BookAuth> GetChildBooks()
        {
            var booksOwner = _bookService.GetBooks("Child");
            if (booksOwner == null) { return new List<BookAuth>(); }
            return booksOwner;
        }

        [HttpGet]
        [Route("GetAdultBooks")]
        public IEnumerable<BookAuth> GetAdultBooks()
        {
            var booksOwner = _bookService.GetBooks("Adult");
            if (booksOwner == null) { return new List<BookAuth>(); }
            return booksOwner;
        }
        
    }
}
