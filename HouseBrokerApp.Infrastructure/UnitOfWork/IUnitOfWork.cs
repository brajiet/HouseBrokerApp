using HouseBrokerApp.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBrokerApp.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPropertyListing PropertyListing { get; }
        IBrokerDetails  BrokerDetails { get; }
        IPropertyImage  PropertyImage { get; }
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
