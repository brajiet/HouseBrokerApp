using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBrokerApp.Domain.Models
{
    public class CardInformation
    {
        [Key]
        public int CardId { get; set; }
        public int? RatingId { get; set; }
        public virtual  Rating Rating { get; set; }
        public required string PreferredBuilding { get; init; }
        public required string Reason { get; init; }
        public required string WhatTheyLike { get; init; }
        public required decimal AmountToInvest { get; init; }
        public required string DiscoveredThrough { get; init; }
        public  int UserId { get; set; }
        public bool IsActive { get; set; }
        public string CurrentStatus { get; set; }
    }
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }
        public int PropertyId { get; set; }
        public virtual PropertyDetail Property { get; set; }
        public int UserId { get; set; }
        public int RatingNo { get; init; }
        public string Comment { get; init; }
        public int RatingUserNo { get; init; }
    }
}
