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

        [Test]
        public async Task GetById_ReturnsCorrectListing()
        {
            // Arrange
            int id = 123;
            var expectedListing = new PropertyDetailVM
            {
                Id = 1,
                BuildingNo = "123",
                BuildingName = "Sample Building",
                Location = "Sample Location",
                StreetAddress = "Sample Address",
                ContactPerson = "John Doe",
                PropertyValuation = 100000, // Example value for decimal property
                NearestLandmark = "Sample Landmark",
                ContactNumber = "1234567890",
                FeaturesofBuildings = "Sample Features",
                Images = "image1.jpg",
                Images1 = "image2.jpg",
                Images2 = "image3.jpg",
                Images3 = "image4.jpg",
                RegisteredPropertyOwner = "Owner Name",
                YearBuilt = "2000",
                TotalAreaCovered = "1000 sq ft"
            };
            _mockPropertyListing.Setup(repo => repo.GetById(id)).ReturnsAsync(expectedListing);

            // Act
            var result = await _controller.GetById(id) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(expectedListing, result.Value);
        }

        [Test]
        public async Task GetById_ReturnsNotFoundWhenListingNotFound()
        {
            // Arrange
            int id = 456;
            _mockPropertyListing.Setup(repo => repo.GetById(id)).ReturnsAsync((PropertyDetailVM)null);

            // Act
            var result = await _controller.GetById(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task Create_ReturnsOkResultWhenListingCreated()
        {
            // Arrange
            var newListing = new PropertyDetailVM
            {
                // Set required properties and any additional properties as needed
                BuildingNo = "123",
                BuildingName = "Sample Building",
                Location = "Sample Location",
                StreetAddress = "Sample Address",
                ContactPerson = "John Doe",
                PropertyValuation = 100000, // Example value for decimal property
                NearestLandmark = "Sample Landmark",
                ContactNumber = "1234567890",
                FeaturesofBuildings = "Sample Features",
                Images = "image1.jpg",
                Images1 = "image2.jpg",
                Images2 = "image3.jpg",
                Images3 = "image4.jpg",
                RegisteredPropertyOwner = "Owner Name",
                YearBuilt = "2000",
                TotalAreaCovered = "1000 sq ft"
            };

            _mockPropertyListing.Setup(repo => repo.Create(newListing)).ReturnsAsync(1);

            // Act
            var result = await _controller.Create(newListing) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task Create_ReturnsInternalServerErrorWhenExceptionThrown()
        {
            // Arrange
            var newListing = new PropertyDetailVM
            {
                // Set required properties and any additional properties as needed
                BuildingNo = "123",
                BuildingName = "Sample Building",
                Location = "Sample Location",
                StreetAddress = "Sample Address",
                ContactPerson = "John Doe",
                PropertyValuation = 100000, // Example value for decimal property
                NearestLandmark = "Sample Landmark",
                ContactNumber = "1234567890",
                FeaturesofBuildings = "Sample Features",
                Images = "image1.jpg",
                Images1 = "image2.jpg",
                Images2 = "image3.jpg",
                Images3 = "image4.jpg",
                RegisteredPropertyOwner = "Owner Name",
                YearBuilt = "2000",
                TotalAreaCovered = "1000 sq ft"
            };

            _mockPropertyListing.Setup(repo => repo.Create(newListing)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.Create(newListing) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
            Assert.AreEqual("Internal Server Error", result.Value);
        }

        [Test]
        public async Task Update_ReturnsOkResultWhenListingUpdated()
        {
            // Arrange
            int idToUpdate = 123; // Id of the listing to update
            var updatedListing = new PropertyDetailVM
            {
                Id = idToUpdate,
                // Set other properties to update as needed
                BuildingNo = "456",
                BuildingName = "Updated Building Name",
                Location = "Updated Location",
                StreetAddress = "Updated Address",
                ContactPerson = "Updated Contact Person",
                PropertyValuation = 150000, // Example value for decimal property
                NearestLandmark = "Updated Landmark",
                ContactNumber = "9876543210",
                FeaturesofBuildings = "Updated Features",
                Images = "updated_image1.jpg",
                Images1 = "updated_image2.jpg",
                Images2 = "updated_image3.jpg",
                Images3 = "updated_image4.jpg",
                RegisteredPropertyOwner = "Updated Owner Name",
                YearBuilt = "2020",
                TotalAreaCovered = "2000 sq ft"
            };

            _mockPropertyListing.Setup(repo => repo.Update(updatedListing)).ReturnsAsync(true);

            // Act
            var result = await _controller.Update(updatedListing) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task Update_ReturnsInternalServerErrorWhenExceptionThrown()
        {
            // Arrange
            var updatedListing = new PropertyDetailVM
            {
                // Set required properties and any additional properties as needed
                BuildingNo = "123",
                BuildingName = "Sample Building",
                Location = "Sample Location",
                StreetAddress = "Sample Address",
                ContactPerson = "John Doe",
                PropertyValuation = 100000, // Example value for decimal property
                NearestLandmark = "Sample Landmark",
                ContactNumber = "1234567890",
                FeaturesofBuildings = "Sample Features",
                Images = "image1.jpg",
                Images1 = "image2.jpg",
                Images2 = "image3.jpg",
                Images3 = "image4.jpg",
                RegisteredPropertyOwner = "Owner Name",
                YearBuilt = "2000",
                TotalAreaCovered = "1000 sq ft"
            };

            _mockPropertyListing.Setup(repo => repo.Update(updatedListing)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.Update(updatedListing) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
            Assert.AreEqual("Internal Server Error", result.Value);
        }

        [Test]
        public async Task Delete_ReturnsOkResultWhenListingDeleted()
        {
            // Arrange
            int idToDelete = 123; // Id of the listing to delete

            _mockPropertyListing.Setup(repo => repo.Delete(idToDelete)).ReturnsAsync(true);

            // Act
            var result = await _controller.Delete(idToDelete) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task Delete_ReturnsInternalServerErrorWhenExceptionThrown()
        {
            // Arrange
            int idToDelete = 789; // Id of the listing to delete

            _mockPropertyListing.Setup(repo => repo.Delete(idToDelete)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.Delete(idToDelete) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
            Assert.AreEqual("Internal Server Error", result.Value);
        }

    }
}
