using System;
using System.Collections.Generic;

namespace AvaItineraryPlanner
{
    public class City
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int Days { get; set; }
        public string Accommodation { get; set; }
        public decimal AccommodationCost { get; set; }
        public decimal FlightCost { get; set; }
        public List<Activity> Activities { get; set; }

        // Constructor for City class
        public City(string name, string country, int days, string accommodation, decimal accommodationCost, decimal flightCost, List<Activity> activities)
        {
            Name = name;
            Country = country;
            Days = days;
            Accommodation = accommodation;
            AccommodationCost = accommodationCost;
            FlightCost = flightCost;
            Activities = activities;
        }
    }
}
