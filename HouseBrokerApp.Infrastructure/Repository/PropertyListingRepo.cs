
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HouseBrokerApp.Data;
using HouseBrokerApp.Data.Entities;
using HouseBrokerApp.Domain.Models;
using HouseBrokerApp.Infrastructure.Interface;
using HouseBrokerApp.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBrokerApp.Infrastructure.Repository
{
    public class PropertyListingRepo : IPropertyListing
    {
        private readonly ApplicationDBContext _context;
        private IMapper _mapper;
        private readonly ILogger<PropertyListingRepo> _logger;
        public PropertyListingRepo(ApplicationDBContext context, IMapper mapper, ILogger<PropertyListingRepo> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public PropertyListingRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PropertyDetailVM>> GetAll()
        {
            try
            {
                var propertyDetails = await _context.PropertyDetail.ToListAsync();
                var propertyDetailVMs = _mapper.Map<IEnumerable<PropertyDetail>, IEnumerable<PropertyDetailVM>>(propertyDetails);
                return propertyDetailVMs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching property details from the database.");
                throw;
            }
           
        }
        public async Task<int> Create(PropertyDetailVM listing)
        {
            try
            {
                listing.Id = 0;
                var propertyDetailEntity = _mapper.Map<PropertyDetailVM, PropertyDetail>(listing);
                await _context.PropertyDetail.AddAsync(propertyDetailEntity);
                await _context.SaveChangesAsync();
                return propertyDetailEntity.Id;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error Adding to database.");
                throw;
            }
           
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var propertyDetail = await _context.PropertyDetail.FindAsync(id);
                if (propertyDetail == null)
                    return false;

                _context.PropertyDetail.Remove(propertyDetail);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on Deletion.");
                throw;
            }
            
        }

        public async Task<PropertyDetailVM> GetById(int id)
        {
            try
            {
                var propertyDetail = await _context.PropertyDetail.FindAsync(id);
                var propertyDetailVM = _mapper.Map<PropertyDetail, PropertyDetailVM>(propertyDetail);
                return propertyDetailVM;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error on getting Data.");
                throw;
            }
           
        }

        public async Task<bool> Update(PropertyDetailVM listing)
        {
            try
            {
                var existingPropertyDetail = await _context.PropertyDetail.FindAsync(listing.Id);
                if (existingPropertyDetail == null)
                    return false;

                _mapper.Map(listing, existingPropertyDetail);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error on Updating Data.");
                throw;
            }
           
        }
        public async Task<IEnumerable<PropertyDetail>> SearchByParams(string? location, decimal? minPrice, decimal? maxPrice, string? propertyType)
        {
            try
            {
                IQueryable<PropertyDetail> query = _context.PropertyDetail;

                if (!string.IsNullOrEmpty(location))
                    query = query.Where(p => p.Location.Contains(location));

                if (minPrice.HasValue)
                    query = query.Where(p => p.PropertyValuation >= minPrice);

                if (maxPrice.HasValue)
                    query = query.Where(p => p.PropertyValuation <= maxPrice);

                if (!string.IsNullOrEmpty(propertyType))
                    query = query.Where(p => p.PropertyType == propertyType);

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error on Searching Data.");
                throw;
            }
           
        }
    }
}
