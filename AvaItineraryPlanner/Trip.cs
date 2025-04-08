using System;
using System.Collections.Generic;

public class Trip
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Budget { get; set; }
    public List<City> Cities { get; set; }

    public Trip(string name, DateTime startDate, DateTime endDate, double budget)
    {
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        Budget = budget;
        Cities = new List<City>();
    }

    public void AddCity(City city)
    {
        Cities.Add(city);
    }

    public void DisplayItinerary()
    {
        Console.WriteLine($"Trip: {Name}");
        Console.WriteLine($"From: {StartDate.ToShortDateString()} To: {EndDate.ToShortDateString()}");
        Console.WriteLine($"Budget: ${Budget}");
        Console.WriteLine("\nCities and Activities:");
        foreach (var city in Cities)
        {
            city.DisplayCityDetails();
        }
    }
}
