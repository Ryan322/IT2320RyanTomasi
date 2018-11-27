using System;
using System.Web.Mvc;
using System.Net;
// using System.Data.Entity; (doesn't work)
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieStore.Controllers;
using MovieStore.Models;
using Moq;

namespace MovieStore.Tests.Controllers
{
    [TestClass]
    public class MovieStoreControllerTest
    {
        [TestMethod]
        public void MovieStore_Index_TestView()
        {
            // Arrange
            MoviesController controller = new MoviesController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStore_ListofMovies()
        {
            // Arrange
            MoviesController controller = new MoviesController();
            // Act
            var result = controller.ListofMovies();
            // Assert
            Assert.AreEqual("Terminator 1", result[0].Title);
            Assert.AreEqual("Terminator 2", result[1].Title);
            Assert.AreEqual("Terminator 3", result[2].Title);
        }

        [TestMethod]
        public void MovieStore_IndexRedirect_Success()
        {
            // Arrange
            MoviesController controller = new MoviesController();
            // Act
            var result = controller.IndexRedirect(1) as RedirectToRouteResult;
            // Assert
            Assert.AreEqual("Create", result.RouteValues["action"]);
            Assert.AreEqual("HomeController", result.RouteValues["controller"]);
        }

        [TestMethod]
        public void MovieStore_IndexRedirect_BadRequest()
        {
            // Arrange
            MoviesController controller = new MoviesController();
            // Act
            var result = controller.IndexRedirect(0) as HttpStatusCodeResult;
            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode) result.StatusCode);
        }

        [TestMethod]
        public void MovieStore_ListFromDb()
        {
            // Step 1
            var list = new List<Movie>
            {
                new Movie() {MovieId=1, Title="Jaws" },
                new Movie() { MovieId=2, Title="Jurassic Park"}
            }.AsQueryable();

            // Step 2
            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            // Step 3
            mockSet.As<IOrderedQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator);
            
            // Step 4
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            // Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            // Act
            ViewResult result = controller.ListFromDb() as ViewResult;
            List<Movie> resultModel = result.Model as List<Movie>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Jaws", resultModel[0].Title);
            Assert.AreEqual("Jurassic Park", resultModel[0].Title);
        }

        [TestMethod]
        public void MovieStore_Details_No_Id()
        {
            // Arrange

            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            var list = new List<Movie>
            {
                new Movie() {MovieId=1, Title="Jaws" },
                new Movie() { MovieId=2, Title="Jurassic Park"}
            }.AsQueryable();

            mockSet.As<IOrderedQueryable<Movie>>().Setup(m => m.Provider()).Returns(list.Provider);
            mockSet.As<IOrderedQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator);
            mockSet.As<IOrderedQueryable<Movie>>().Setup(m => m.Expression()).Returns(list.Expression);
            mockSet.As<IOrderedQueryable<Movie>>().Setup(m => m.ElementType()).Returns(list.ElementType);
            mockSet.Setup(m => m.Find(It.IsAny<Object>())).Returns(list.First());

            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            // Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            // Act
            HttpStatusCodeResult result = controller.Details(null) as HttpStatusCode;

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)result.StatusCode);
        }

        [TestMethod]
        public void MovieStore_Details_MovieNull()
        {
            // Arrange

            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            var list = new List<Movie>
            {
                new Movie() {MovieId=1, Title="Jaws" },
                new Movie() { MovieId=2, Title="Jurassic Park"}
            }.AsQueryable();

            mockSet.As<IOrderedQueryable<Movie>>().Setup(m => m.Provider()).Returns(list.Provider);
            mockSet.As<IOrderedQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator);
            mockSet.As<IOrderedQueryable<Movie>>().Setup(m => m.Expression()).Returns(list.Expression);
            mockSet.As<IOrderedQueryable<Movie>>().Setup(m => m.ElementType()).Returns(list.ElementType);

            Movie movie = null;
            mockSet.Setup(m => m.Find(It.IsAny<Object>())).Returns(movie);

            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            // Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            // Act
            HttpStatusCodeResult result = controller.Details(1) as HttpStatusCodeResult;

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, (HttpStatusCode)result.StatusCode);
        }



    }
}
