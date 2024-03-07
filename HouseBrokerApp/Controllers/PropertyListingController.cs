using HouseBrokerApp.Domain.Models;
using HouseBrokerApp.Infrastructure.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static System.Net.Mime.MediaTypeNames;

namespace HouseBrokerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyListingController : ControllerBase
    {
        private readonly IPropertyListing _propertylisting;
        private readonly IWebHostEnvironment _environment;

        public PropertyListingController(IPropertyListing propertylisting, IWebHostEnvironment environment)
        {
            _propertylisting = propertylisting;
            _environment = environment; 
        }

        [HttpPost]
        [Route("create")]
       // [Authorize]
        public async Task<IActionResult> Create([FromForm] PropertyDetailVM listing)
        {
            try
            {
                //if (listing.Images == null || listing.Images1 == null)
                //{
                //    return Content("File not selected");
                //}

                var directoryPath = Path.Combine(_environment.ContentRootPath, "Images");

                // Ensure directory exists or create it
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                //var imageName1 = Guid.NewGuid().ToString() + Path.GetExtension(listing.ImagesFile.FileName);
               // var imageName2 = Guid.NewGuid().ToString() + Path.GetExtension(listing.ImagesFile1.FileName);

                // Combine base path with file names
              //  var imagePath1 = Path.Combine(directoryPath, imageName1);
               // var imagePath2 = Path.Combine(directoryPath, imageName2);

               // listing.Images = imageName1;
               // listing.Images1 = imageName2;
                // Copy the images asynchronously
                //using (var stream1 = new FileStream(imagePath1, FileMode.Create))
                //using (var stream2 = new FileStream(imagePath2, FileMode.Create))
                //{
                //   await listing.ImagesFile.CopyToAsync(stream1);
                //    await listing.ImagesFile1.CopyToAsync(stream2);
                //}
                var result = await _propertylisting.Create(listing);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] PropertyDetailVM listing)
        {
            try
            {
                var result = await _propertylisting.Update(listing);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _propertylisting.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {

            try
            {
                var users = await _propertylisting.GetAll();
                return Ok(users); 
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet]
        [Route("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var listing = await _propertylisting.GetById(id);
                if (listing == null)
                    return NotFound(); // Return 404 if listing is not found
                return Ok(listing);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }

        //[HttpGet]
        //[Route("getimagebyid/{id}")]
        //public async Task<IActionResult> GetImageById(int id)
        //{
        //    // Get the image path from the database
        //    var property = await _propertylisting.GetById(id);

        //    if (property.Images == null || property.Images1 == null)
        //        return NotFound();

        //    var directoryPath = Path.Combine(_environment.ContentRootPath, "Images");

        //    // Combine the content root path with the image path
        //    string fullPath = Path.Combine(directoryPath, property.Images);
        //    string fullPath1 = Path.Combine(directoryPath, property.Images1);
        //    // Check if the file exists
        //    if (!System.IO.File.Exists(fullPath))
        //        return NotFound();
        //    if (!System.IO.File.Exists(fullPath1))
        //        return NotFound();
        //    // Return the image file directly
        //    var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
        //    var stream1 = new FileStream(fullPath1, FileMode.Open, FileAccess.Read);
        //    return new FileStreamResult(stream, "image/jpeg"); // Adjust content type as per your image type
        //}
    }

}
