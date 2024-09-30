using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BupaAssessmentAPI.Models;
using NUnit.Framework.Legacy;

namespace BupaAssessmentAPI.Test
{
    public class ApiServiceTest
    {
        private readonly IBook _bookService;

        public ApiServiceTest()
        {
            _bookService = new BookInformationImpl();
        }

        [Test]
        public void Is_ChildList_Empty_Test()
        {
            //Arrange
            BookInformationImpl bookInformationImpl = new BookInformationImpl();
            List<BookAuth> bookAuthor = new List<BookAuth>
            {
                new BookAuth
                {
                    name = "Satish",
                    age = 22,
                    Books = new List<Book>
                    {
                        new Book { name = "Book1", type = "Story" },
                        new Book { name = "Book2", type = "Myth" }
                    }
                }
            };

            //Act
            var book = bookInformationImpl.FetchBooks(bookAuthor);

            //Assert
            Assert.That(book.ContainsKey("child"), Is.False);
        }

        [Test]
        public void Is_AdultList_Empty_Test()
        {
            //Arrange
            BookInformationImpl bookInformationImpl = new BookInformationImpl();
            List<BookAuth> bookAuthor = new List<BookAuth>
            {
                new BookAuth
                {
                    name = "Satish",
                    age = 16,
                    Books = new List<Book>
                    {
                        new Book { name = "Book1", type = "Story" },
                        new Book { name = "Book2", type = "Myth" }
                    }
                }
            };

            //Act
            var book = bookInformationImpl.FetchBooks(bookAuthor);

            //Assert
            Assert.That(book.ContainsKey("adult"), Is.False);
        }
    }
}
