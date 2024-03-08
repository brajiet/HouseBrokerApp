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

        public BrokerDetailsRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public BrokerDetailsRepo(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BrokerDetailsVM>> GetAll()
        {
            var brokerDetails = await _context.BrokerDetail.ToListAsync();
            var BrokerDetailsVMs = _mapper.Map<IEnumerable<BrokerDetail>, IEnumerable<BrokerDetailsVM>>(brokerDetails);
            return BrokerDetailsVMs;
        }
        public async Task<int> Create(BrokerDetailsVM listing)
        {
            var brokerDetails = _mapper.Map<BrokerDetailsVM, BrokerDetail>(listing);
            await  _context.BrokerDetail.AddAsync(brokerDetails);
            return brokerDetails.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var brokerDetails = await _context.BrokerDetail.FindAsync(id);
            if (brokerDetails == null)
                return false;

            _context.BrokerDetail.Remove(brokerDetails);
            return true;
        }

        public async Task<BrokerDetailsVM> GetById(int id)
        {
            var brokerDetails = await _context.BrokerDetail.FindAsync(id);
            var BrokerDetailsVM = _mapper.Map<BrokerDetail, BrokerDetailsVM>(brokerDetails);
            return BrokerDetailsVM;
        }

        public async Task<bool> Update(BrokerDetailsVM brokerDetails)
        {
            var existingbrokerDetails = await _context.BrokerDetail.FindAsync(brokerDetails.Id);
            if (existingbrokerDetails == null)
                return false;

            _mapper.Map(brokerDetails, existingbrokerDetails);
            return true;
        }
    }
}
