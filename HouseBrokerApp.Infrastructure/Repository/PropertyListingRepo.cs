
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HouseBrokerApp.Data;
using HouseBrokerApp.Data.Entities;
using HouseBrokerApp.Domain.Models;
using HouseBrokerApp.Infrastructure.Interface;
using HouseBrokerApp.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public PropertyListingRepo(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PropertyDetailVM>> GetAll()
        {
            var propertyDetails = await _context.PropertyDetail.ToListAsync();
            var propertyDetailVMs = _mapper.Map<IEnumerable<PropertyDetail>, IEnumerable<PropertyDetailVM>>(propertyDetails);
            return propertyDetailVMs;
        }
        public async Task<int> Create(PropertyDetailVM listing)
        {
            var propertyDetailEntity = _mapper.Map<PropertyDetailVM, PropertyDetail>(listing);
            _context.PropertyDetail.Add(propertyDetailEntity);
            await _context.SaveChangesAsync();
            return propertyDetailEntity.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var propertyDetail = await _context.PropertyDetail.FindAsync(id);
            if (propertyDetail == null)
                return false;

            _context.PropertyDetail.Remove(propertyDetail);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PropertyDetailVM> GetById(int id)
        {
            var propertyDetail = await _context.PropertyDetail.FindAsync(id);
            var propertyDetailVM = _mapper.Map<PropertyDetail, PropertyDetailVM>(propertyDetail);
            return propertyDetailVM;
        }

        public async Task<bool> Update(PropertyDetailVM listing)
        {
            var existingPropertyDetail = await _context.PropertyDetail.FindAsync(listing.Id);
            if (existingPropertyDetail == null)
                return false;

            _mapper.Map(listing, existingPropertyDetail);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<PropertyDetail>> SearchByParams(string location, decimal? minPrice, decimal? maxPrice, string propertyType)
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
    }
}
