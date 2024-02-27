using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBrokerApp.Domain.Models
{
    public class RegistrationVM
    {
        public long Id { get; set; }
        [StringLength(20)]
        public required string FirstName { get; set; }
        [StringLength(20)]
        public string? MiddleName { get; set; }
        [StringLength(20)]
        public required string LastName { get; set; }
        [StringLength(30)]
        public required string PermanentAddress { get; set; }
        [StringLength(30)]
        public required string TemporaryAddress { get; set; }
        [StringLength(10)]
        public required string ContactNo { get; set; }
        [StringLength(10)]
        public string? ContactNo1 { get; set; }
        [StringLength(25)]
        public required string CitizenShipNo { get; set; }
        [StringLength(25)]
        public required string CitizenShipIssuedFrom { get; set; }
        public DateTime CitizenShipIssuedDate { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required string Password { get; set; }
        public bool IsBroker { get; set; }
    }
}