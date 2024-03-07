using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBrokerApp.Domain.Models
{
    public class PropertyImageVM
    {
        [Key]
        public int Id { get; set; }
        public int ProperyId { get; set; }
        public required string Image { get; set; }
        public required string Description { get; set; }
        public required PropertyDetailVM PropertyDetail { get; set; }
    }
}
