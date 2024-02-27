using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBrokerApp.Domain.Models
{
    public class PropertyDetailVM

    {
        [Key]
        public int Id { get; init; }
        [StringLength(30)]
        public required string BuildingNo { get; set; }
        [StringLength(30)]
        public required string  Name { get; init; }
        [StringLength(30)]
        public required string Location { get; init; }
        [StringLength(30)]
        public required string StreetAddress { get; init; }
        [StringLength(30)]
        public required string ContactPerson { get; init; }
        public decimal PropertyValuation { get; init; }
        [StringLength(30)]
        public required string NearestLandmark { get; init; }
        [StringLength(30)]
        public required string ContactNumber { get; init; }
        public required string Images { get; init; }
        public required string Images1 { get; init; }
        public required string Images2 { get; init; }
        public required string Images3 { get; init; }

        [Display(Name= "Registered Property Owner")]
        public required string RegisteredPropertyOwner { get; init; }
        public required string YearBuilt { get; init; }
        public required string TotalArea { get; init; }
    }

}
