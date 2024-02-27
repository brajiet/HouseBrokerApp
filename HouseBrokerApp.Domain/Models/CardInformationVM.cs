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
        public  RatingVM Rating { get; set; }
        public required string PreferredBuilding { get; init; }
        public required string Reason { get; init; }
        public required string WhatTheyLike { get; init; }
        public required decimal AmountToInvest { get; init; }
        public required string DiscoveredThrough { get; init; }
        public  int UserId { get; set; }
        public bool IsActive { get; set; }
        public string CurrentStatus { get; set; }
    }
    public class RatingVM
    {
        [Key]
        public int RatingId { get; set; }
        public int PropertyId { get; set; }
        public PropertyDetailVM Property { get; set; }
        public int UserId { get; set; }
        public int Rating { get; init; }
        public string Comment { get; init; }
        public int RatingUserNo { get; init; }
    }
}
