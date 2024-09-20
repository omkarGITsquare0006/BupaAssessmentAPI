using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BupaAssessmentAPI.Models;
using Microsoft.Extensions.Logging;
using NUnit.Framework.Legacy;

namespace BupaAssessmentAPI.Test
{
    public class GetBooksByAgeTests
    {
        private readonly IBook _book;
        public GetBooksByAgeTests()
        {
            _book = new BookInformationImpl();
        }
        
        [Test]
        [TestCase("All",4)]
        [TestCase("Child", 2)]
        [TestCase("Adult", 2)]
        [TestCase("XYZ", 0)]
        public void GetBooks_ByAge_OrAll_Test(string category, int expected)
        {
            //Arrange
            var BookDetails = _book.GetBooks(category);

            //Act
            int actual = BookDetails.Count();

           //Assert
           ClassicAssert.AreEqual(expected, actual);
        }
    }
}
