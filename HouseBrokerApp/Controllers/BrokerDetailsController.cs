using HouseBrokerApp.Domain.Models;
using HouseBrokerApp.Infrastructure.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseBrokerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrokerDetailsController : ControllerBase
    {
        private readonly IBrokerDetails _brokerdetail;

        public BrokerDetailsController(IBrokerDetails brokerdetail)
        {
            _brokerdetail = brokerdetail;
        }
        [HttpPost]
        [Route("create")]
       // [Authorize]
        public async Task<IActionResult> Create([FromBody] BrokerDetailsVM listing)
        {
            try
            {
                var result = await _brokerdetail.Create(listing);
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
        public async Task<IActionResult> Update([FromBody] BrokerDetailsVM listing)
        {
            try
            {
                var result = await _brokerdetail.Update(listing);
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
                var result = await _brokerdetail.Delete(id);
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
                var users = await _brokerdetail.GetAll();
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
                var listing = await _brokerdetail.GetById(id);
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
