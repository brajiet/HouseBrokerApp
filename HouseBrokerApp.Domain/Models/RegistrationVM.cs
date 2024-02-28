﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBrokerApp.Domain.Models
{
    public class RegistrationVM
    {
        
        [EmailAddress]
        public required string Email { get; set; }
        public required string Password { get; set; }
        public bool IsBroker { get; set; }
    }
}