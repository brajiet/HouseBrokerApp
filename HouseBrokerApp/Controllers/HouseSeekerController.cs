using HouseBrokerApp.Infrastructure.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using HouseBrokerApp.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace HouseBrokerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HouseSeekerController : ControllerBase
    {
        private readonly IPropertyListing _propertylisting;

        public HouseSeekerController(IPropertyListing propertylisting)
        {
            _propertylisting = propertylisting;
        }

        [HttpGet]
        [Route("searchproperties")]

        public async Task<ActionResult<IEnumerable<PropertyDetailVM>>> SearchProperties(
        string? location, decimal? minPrice, decimal? maxPrice, string? propertyType)
        {
            var result = await _propertylisting.SearchByParams(location ?? "", minPrice, maxPrice, propertyType ?? "");
            return Ok(result);
        }
        
    }
}
