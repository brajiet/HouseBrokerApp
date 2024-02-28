using AutoMapper;
using HouseBrokerApp.Data.Entities;
using HouseBrokerApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBrokerApp.Infrastructure.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<PropertyDetailVM, PropertyDetail>();
            CreateMap<PropertyDetailVM, PropertyDetail>().ReverseMap();
        }
       
    }
}
