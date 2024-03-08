using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBrokerApp.Data.Entities
{
    public class PropertyImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PropertyDetailId { get; set; }
        public virtual PropertyDetail PropertyDetail { get; set; }
        public required string Image { get; set; }
        public required string Description { get; set; }
        public DateTime AddedeDate { get; set; }
        public bool IsActive { get; set; }
    }
}
