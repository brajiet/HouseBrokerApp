using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBrokerApp.Data.Entities
{
    public class CardInformation
    {
        [Key]
        public int CardId { get; set; }
        public int? RatingId { get; set; }
        public virtual  Rating Rating { get; set; }
        public required string PreferredBuilding { get; set; }
        public required string Reason { get; set; }
        public required string WhatTheyLike { get; set; }
        public required decimal AmountToInvest { get; set; }
        public required string DiscoveredThrough { get; set; }
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
        public int RatingNo { get; set; }
        public string Comment { get; set; }
        public int RatingUserNo { get; set; }
    }
}
