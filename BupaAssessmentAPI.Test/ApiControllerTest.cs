using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using BupaAssessmentAPI.Controllers;
using BupaAssessmentAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework.Legacy;

namespace BupaAssessmentAPI.Test
{
    public class ApiControllerTest
    {
        private readonly IBook _bookService;
        private readonly BookController _bookController;

        public ApiControllerTest()
        {
            _bookService = new BookInformationImpl();
            _bookController = new BookController(_bookService);
        }
        [Test]
        public void GetBookControllerTest()
        {
            // Arrange
            IBook bookService = _bookService;
            var controller = new BookController(bookService);

            // Act
            var response = controller.GetBooks();

            // Assert
            Assert.That(response.GetType(), Is.EqualTo(typeof(OkObjectResult)));
        }

        [Test]
        public void Mock_Book_Test()
        {
            // Arrange
            var bookServiceMock = new Mock<IBook>();
            Dictionary<string,List<string>> dumDict = new Dictionary<string,List<string>>();
            dumDict.Add("child", new List<string> { "Elephant House", "b1", "b2" });
            dumDict.Add("adult", new List<string> { "ba1", "ba3"});
            bookServiceMock.Setup(ser => ser.GetBooks()).ReturnsAsync(dumDict);

            // Act
            var controller = new BookController(bookServiceMock.Object);
            var response = controller.GetBooks();

            // Assert
            Assert.That(response.GetType(), Is.EqualTo(typeof(OkObjectResult)));
        }
    }
}
