using BookMyMovie.Controllers;
using BookMyMovie.Data.Models;
using BookMyMovie.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace BookMyMovie.Test
{
    [TestClass]
    public class MoviesControllerTest
    {
        private readonly Mock<IMovieService> _mockMovieService;
        private readonly Mock<ILogger<MoviesController>> _mockLogger;

        public MoviesControllerTest()
        {
            _mockMovieService = new Mock<IMovieService>();
            _mockLogger = new Mock<ILogger<MoviesController>>();
        }

        private List<Movie> GetTestMovieObjects()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Title = "Test Movie1", ImdbID = "imdb1001", ImdbRating = "9", Language = "Hindi", ListingType = "UP_COMING", Location = "Delhi" },
                new Movie { Id = 2, Title = "Test Movie2", ImdbID = "imdb1002", ImdbRating = "8", Language = "Hindi", ListingType = "UP_COMING", Location = "Delhi" },
                new Movie { Id = 3, Title = "Test Movie3", ImdbID = "imdb1003", ImdbRating = "7", Language = "Hindi", ListingType = "UP_COMING", Location = "Delhi" }
            };
        }

        [TestMethod]
        public void Get_Should_Return_Success()
        {
            // Arrange
            List<Movie> movies = GetTestMovieObjects();

            // Act
            _mockMovieService.Setup(x => x.GetAll()).Returns(movies);
            MoviesController controller = new MoviesController(_mockMovieService.Object, _mockLogger.Object);
            var result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(movies.GetType(), ((OkObjectResult)result).Value.GetType());
            Assert.AreEqual("Test Movie1", ((List<Movie>)((OkObjectResult)result).Value)[0].Title);
        }

        [TestMethod]
        public void GetById_Should_Return_Success()
        {
            // Arrange
            List<Movie> movies = GetTestMovieObjects();
            _mockMovieService.Setup(x => x.GetById(It.Is<string>(x => x == "Test Movie2"))).Returns((string id) => movies.FirstOrDefault(y => id == y.Title));
            MoviesController controller = new MoviesController(_mockMovieService.Object, _mockLogger.Object);

            // Act
            var result = controller.GetById("Test Movie2");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(Movie), ((OkObjectResult)result).Value.GetType());
            Assert.AreEqual("Test Movie2", ((Movie)((OkObjectResult)result).Value).Title);
        }

        [TestMethod]
        public void GetMovie_Return_Null_When_Empty_Id()
        {
            //Arrange
            Movie movie = null;
            string testMovieId = string.Empty;
            _mockMovieService.Setup(x => x.GetById(testMovieId)).Returns(movie);

            // Act
            MoviesController controller = new MoviesController(_mockMovieService.Object, _mockLogger.Object);
            var result = controller.GetById(testMovieId);

            // Assert
            Assert.IsNull(((OkObjectResult)result).Value);
        }
    }
}
