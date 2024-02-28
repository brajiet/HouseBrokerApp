using AutoMapper;
using HouseBrokerApp.Data;
using HouseBrokerApp.Data.Entities;
using HouseBrokerApp.Domain.Models;
using HouseBrokerApp.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBrokerApp.Infrastructure.Repository
{
    public class BrokerDetailsRepo : IBrokerDetails
    {
        private readonly ApplicationDBContext _context;
        private IMapper _mapper;

        public BrokerDetailsRepo(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BrokerDetailsVM>> GetAll()
        {
            var propertyDetails = await _context.PropertyDetail.ToListAsync();
            var BrokerDetailsVMs = _mapper.Map<IEnumerable<PropertyDetail>, IEnumerable<BrokerDetailsVM>>(propertyDetails);
            return BrokerDetailsVMs;
        }
        public async Task<int> Create(BrokerDetailsVM listing)
        {
            var propertyDetailEntity = _mapper.Map<BrokerDetailsVM, PropertyDetail>(listing);
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

        public async Task<BrokerDetailsVM> GetById(int id)
        {
            var propertyDetail = await _context.PropertyDetail.FindAsync(id);
            var BrokerDetailsVM = _mapper.Map<PropertyDetail, BrokerDetailsVM>(propertyDetail);
            return BrokerDetailsVM;
        }

        public async Task<bool> Update(BrokerDetailsVM listing)
        {
            var existingPropertyDetail = await _context.PropertyDetail.FindAsync(listing.Id);
            if (existingPropertyDetail == null)
                return false;

            _mapper.Map(listing, existingPropertyDetail);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
