using System;
using System.Collections.Generic;

namespace AvaItineraryPlanner
{
    public class Trip
    {
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public List<City> Cities { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Trip(string name, decimal budget, List<City> cities, DateTime startDate, DateTime endDate)
        {
            Name = name;
            Budget = budget;
            Cities = cities;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
