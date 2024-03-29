﻿using HouseBrokerApp.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseBrokerApp.Data
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<CardInformation> CardInformation { get; set; }
        public DbSet<PropertyDetail> PropertyDetail { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<BrokerDetail> BrokerDetail { get; set; }

    }
}
