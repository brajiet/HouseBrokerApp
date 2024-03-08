using HouseBrokerApp.Data;
using HouseBrokerApp.Infrastructure.Interface;
using HouseBrokerApp.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBrokerApp.Infrastructure.UnitOfWork
{
    public class UnitOfWorkRepo : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        public UnitOfWorkRepo(ApplicationDBContext context)
        {
            _context = context;
            PropertyListing = new PropertyListingRepo(context);
            BrokerDetails = new BrokerDetailsRepo(context);
            PropertyImage=new PropertyImageRepo(context);
        }
        public IPropertyListing PropertyListing { get; }
        public IBrokerDetails BrokerDetails { get; }
        public IPropertyImage PropertyImage {get;}

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
