using AutoMapper;
using HouseBrokerApp.Data;
using HouseBrokerApp.Data.Entities;
using HouseBrokerApp.Domain.Models;
using HouseBrokerApp.Infrastructure.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBrokerApp.Infrastructure.Repository
{
    public class PropertyImageRepo : IPropertyImage
    {
        private readonly ApplicationDBContext _context;
        private IMapper _mapper;
        private readonly ILogger<PropertyImageRepo> _logger;
        private readonly IHostEnvironment _environment;
        public PropertyImageRepo(ApplicationDBContext context, IMapper mapper, ILogger<PropertyImageRepo> logger, IHostEnvironment environment)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _environment = environment;
        }
        public PropertyImageRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PropertyImageVM>> GetAll()
        {
            try
            {
                var propertyImage = await _context.PropertyImage.ToListAsync();
                var PropertyImageVMs = _mapper.Map<IEnumerable<PropertyImage>, IEnumerable<PropertyImageVM>>(propertyImage);
                return PropertyImageVMs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching property details from the database.");
                throw;
            }

        }
        public async Task<int> Create(PropertyImageVM listing)
        {
            try
            {
                var propertyImageEntity = _mapper.Map<PropertyImageVM, PropertyImage>(listing);
                _context.PropertyImage.Add(propertyImageEntity);
                await _context.SaveChangesAsync();
                return propertyImageEntity.Id;
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
                var propertyImage = await _context.PropertyImage.FindAsync(id);
                if (propertyImage == null)
                    return false;

                _context.PropertyImage.Remove(propertyImage);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on Deletion.");
                throw;
            }

        }

        public async Task<PropertyImageVM> GetById(int id)
        {
            try
            {
                var propertyImage = await _context.PropertyImage.FindAsync(id);
                var PropertyImageVM = _mapper.Map<PropertyImage, PropertyImageVM>(propertyImage);
                return PropertyImageVM;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error on getting Data.");
                throw;
            }

        }

        public async Task<bool> Update(PropertyImageVM listing)
        {
            try
            {
                var existingPropertyImage = await _context.PropertyImage.FindAsync(listing.Id);
                if (existingPropertyImage == null)
                    return false;

                _mapper.Map(listing, existingPropertyImage);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error on Updating Data.");
                throw;
            }

        }

        public async Task<bool> SaveImage(List<IFormFile> file, int propDetId)
        {
           // PropertyImageVM pImage = new PropertyImageVM();
            var directoryPath = Path.Combine(_environment.ContentRootPath, "Images");

            // Ensure directory exists or create it
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            foreach (var item in file)
            {
                if (file.Count > 0)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FirstOrDefault().FileName;
                    var filePath = Path.Combine(directoryPath, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }
                }
            }
            throw new NotImplementedException();
        }
    }
}
