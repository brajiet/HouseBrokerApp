using HouseBrokerApp.Domain.Models;
using HouseBrokerApp.Infrastructure.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HouseBrokerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyListingController : ControllerBase
    {
        private readonly IPropertyListing _propertylisting;

        public PropertyListingController(IPropertyListing propertylisting)
        {
            _propertylisting = propertylisting;
        }

        [HttpPost]
        [Route("create")]
        //[Authorize(AuthenticationSchemes = "Authentication")]
        public async Task<IActionResult> Create([FromBody] PropertyDetailVM listing)
        {
            try
            {
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
    }
}
