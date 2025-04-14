using System;
using System.Collections.Generic;

public class Trip
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<City> Cities { get; set; }
    public double Budget { get; set; }

    public Trip(string name, DateTime start, DateTime end, double budget)
    {
        Name = name;
        StartDate = start;
        EndDate = end;
        Budget = budget;
        Cities = new List<City>();
    }

    public void AddCity(City city)
    {
        Cities.Add(city);
    }

    public void DisplayItinerary()
    {
        Console.WriteLine($"\nTrip: {Name} ({StartDate.ToShortDateString()} - {EndDate.ToShortDateString()})");
        foreach (var city in Cities)
        {
            Console.WriteLine($"\nCity: {city.Name}, Country: {city.Country}");
            Console.WriteLine($"Accommodation: ${city.AccommodationCost}");
            Console.WriteLine("Activities:");
            foreach (var activity in city.Activities)
            {
                Console.WriteLine($"- {activity.Name} (${activity.Cost})");
            }
        }
    }
}
