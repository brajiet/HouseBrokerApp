using HouseBrokerApp.Controllers;
using HouseBrokerApp.Domain.Models;
using HouseBrokerApp.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBrokerApp.TestCases
{
    public class PropertyListingControllerTest
    {
        private Mock<IPropertyListing> _mockPropertyListing;
        private PropertyListingController _controller;

        [SetUp]
        public void Setup()
        {
            _mockPropertyListing = new Mock<IPropertyListing>();
            _controller = new PropertyListingController(_mockPropertyListing.Object);
        }

        [Test]
        public async Task GetAll_ReturnsOkResultWithData()
        {
            // Arrange
            var expectedData = new List<PropertyDetailVM>();
            _mockPropertyListing.Setup(repo => repo.GetAll()).ReturnsAsync(expectedData);

            // Act
            var result = await _controller.GetAll() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(expectedData, result.Value);
        }

        [Test]
        public async Task GetAll_ReturnsInternalServerErrorWhenExceptionThrown()
        {
            // Arrange
            _mockPropertyListing.Setup(repo => repo.GetAll()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAll() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
            Assert.AreEqual("Internal Server Error", result.Value);
        }
    }
}
