using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBrokerApp.Domain.Models
{
    public class CardInformationVM
    {
        [Key]
        public int CardId { get; set; }
        public int? RatingId { get; set; }
        public  RatingVM? Rating { get; set; }
        public required string PreferredBuilding { get; set; }
        public required string Reason { get; set; }
        public required string WhatTheyLike { get; set; }
        public required decimal AmountToInvest { get; set; }
        public required string DiscoveredThrough { get; set; }
        public  int UserId { get; set; }
        public bool IsActive { get; set; }
        public string? CurrentStatus { get; set; }
    }
    public class RatingVM
    {
        [Key]
        public int RatingId { get; set; }
        public int PropertyId { get; set; }
        public PropertyDetailVM? Property { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public int RatingUserNo { get; set; }
    }
}
