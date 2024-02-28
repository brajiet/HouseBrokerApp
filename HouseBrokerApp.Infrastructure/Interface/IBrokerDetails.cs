using HouseBrokerApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBrokerApp.Infrastructure.Interface
{
    public interface IBrokerDetails
    {
        Task<IEnumerable<BrokerDetailsVM>> GetAll();
        Task<BrokerDetailsVM> GetById(int id);
        Task<int> Create(BrokerDetailsVM listing);
        Task<bool> Update(BrokerDetailsVM listing);
        Task<bool> Delete(int id);
    }
}
