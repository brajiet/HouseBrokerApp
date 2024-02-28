using Microsoft.AspNetCore.Http;
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

        public int Id { get; set; }
        [StringLength(30)]
        public required string BuildingNo { get; set; }
        [StringLength(30)]
        public required string  BuildingName { get; set; }
        [StringLength(30)]
        public required string PropertyType { get; set; }
        [StringLength(30)]
        public required string Location { get; set; }
        [StringLength(30)]
        public required string StreetAddress { get; set; }
        [StringLength(30)]
        public required string ContactPerson { get; set; }
        public decimal PropertyValuation { get; set; }
        [StringLength(30)]
        public required string NearestLandmark { get; set; }
        [StringLength(30)]
        public required string ContactNumber { get; set; }
        public required string FeaturesofBuildings { get; set; }
        public IFormFile ImagesFile { get; set; }
        public string Images { get; set; }
        public IFormFile ImagesFile1 { get; set; }
        public string Images1 { get; set; }

        [Display(Name= "Registered Property Owner")]
        public required string RegisteredPropertyOwner { get; set; }
        public required string YearBuilt { get; set; }
        public required string TotalAreaCovered { get; set; }
    }
    
}
