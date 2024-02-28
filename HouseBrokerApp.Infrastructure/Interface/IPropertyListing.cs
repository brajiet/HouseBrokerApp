using HouseBrokerApp.Data.Entities;
using HouseBrokerApp.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBrokerApp.Infrastructure.Interface
{
    public interface IPropertyListing
    {
        Task<IEnumerable<PropertyDetailVM>> GetAll();
        Task<PropertyDetailVM> GetById(int id);
        Task<int> Create(PropertyDetailVM listing);
        Task<bool> Update(PropertyDetailVM listing);
        Task<bool> Delete(int id);
        Task<IEnumerable<PropertyDetail>> SearchByParams(string location, decimal? minPrice, decimal? maxPrice, string propertyType);
    }
}
