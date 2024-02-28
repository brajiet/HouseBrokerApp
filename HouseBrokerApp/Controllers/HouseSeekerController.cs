using HouseBrokerApp.Infrastructure.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

namespace HouseBrokerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseSeekerController : ControllerBase
    {
        private readonly IPropertyListing _propertylisting;

        public HouseSeekerController(IPropertyListing propertylisting)
        {
            _propertylisting = propertylisting;
        }
        //[HttpPost]
        //[Route("create")]
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Property>>> SearchProperties(
        string location, decimal? minPrice, decimal? maxPrice, string propertyType)
        {
            var result = await _propertylisting.SearchByParams(location, minPrice, maxPrice, propertyType);
            return Ok(result);
        }
    }
}
