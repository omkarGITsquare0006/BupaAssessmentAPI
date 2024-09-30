using System.Linq;
using System.Web.Http;
using BupaAssessmentAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace BupaAssessmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBook _bookService;
        public BookController(IBook bookService)
        {
            _bookService = bookService;
        }

        [HttpGet(Name = "GetAllBooks")]
        public ActionResult GetBooks()
        {
            var books = Task.Run(async () => await _bookService.GetBooks()).Result;
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }

    }
}
