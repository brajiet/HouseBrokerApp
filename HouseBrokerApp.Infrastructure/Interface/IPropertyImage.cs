using HouseBrokerApp.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBrokerApp.Infrastructure.Interface
{
    public interface IPropertyImage
    {
        Task<IEnumerable<PropertyImageVM>> GetAll();
        Task<PropertyImageVM> GetById(int id);
        Task<int> Create(PropertyImageVM listing);
        Task<bool> Update(PropertyImageVM listing);
        Task<bool> Delete(int id);
        Task<bool> SaveImage(List<IFormFile> file,int propDetId);
    }
}
