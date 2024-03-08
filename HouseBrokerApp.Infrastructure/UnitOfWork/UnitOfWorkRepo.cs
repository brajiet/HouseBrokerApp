using HouseBrokerApp.Data;
using HouseBrokerApp.Infrastructure.Interface;
using HouseBrokerApp.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore.Storage;
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
        private IDbContextTransaction _transaction;
        public UnitOfWorkRepo(ApplicationDBContext context,IDbContextTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
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
        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }
        public async Task CommitAsync()
        {
           await  _transaction.CommitAsync();
        }
        public async Task RollbackAsync()
        {
           await _transaction.RollbackAsync();
        }
    }
}
