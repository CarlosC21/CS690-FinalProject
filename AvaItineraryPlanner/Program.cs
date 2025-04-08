using System;
using System.Collections.Generic;

namespace AvaItineraryPlanner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Itinerary Planner!");

            // Placeholder for starting the main functionality
            var planner = new ItineraryPlanner();

            planner.CreateTrip("Vacation!");
            planner.AddDestination("London", new List<string> { "Big Ben", "Stamford Bridge", "English Tea" });
            planner.AddDestination("Rome", new List<string> { "Colosseum", "Visit Vatican", "Eat local food" });

            planner.SetBudget(10000);

            planner.TrackFlights("London", 450); 
            planner.TrackFlights("Rome", 200);  

            planner.TrackHotel("London", 130);   
            planner.TrackHotel("Rome", 120);    

            planner.DisplayItinerary();
        }
    }

    // Core Planner class
    public class ItineraryPlanner
    {
        private string tripName;
        private double budget;
        private List<Destination> destinations;
        private Dictionary<string, double> flightPrices;
        private Dictionary<string, double> hotelPrices;

        public ItineraryPlanner()
        {
            destinations = new List<Destination>();
            flightPrices = new Dictionary<string, double>();
            hotelPrices = new Dictionary<string, double>();
        }

        public void CreateTrip(string name)
        {
            tripName = name;
            Console.WriteLine($"Trip '{tripName}' created successfully!");
        }

        public void SetBudget(double amount)
        {
            budget = amount;
            Console.WriteLine($"Budget set to ${budget}.");
        }

        public void AddDestination(string city, List<string> activities)
        {
            var destination = new Destination(city, activities);
            destinations.Add(destination);
            Console.WriteLine($"Destination {city} added with {activities.Count} activities.");
        }

        public void TrackFlights(string destination, double price)
        {
            flightPrices[destination] = price;
            Console.WriteLine($"Flight to {destination} tracked with price ${price}.");
        }

        public void TrackHotel(string destination, double pricePerNight)
        {
            hotelPrices[destination] = pricePerNight;
            Console.WriteLine($"Hotel in {destination} tracked with price ${pricePerNight} per night.");
        }

        public void DisplayItinerary()
        {
            Console.WriteLine($"\nItinerary for Trip '{tripName}':");
            foreach (var destination in destinations)
            {
                Console.WriteLine($"- {destination.City}:");
                foreach (var activity in destination.Activities)
                {
                    Console.WriteLine($"  - {activity}");
                }
                if (flightPrices.ContainsKey(destination.City))
                {
                    Console.WriteLine($"  Flight Price: ${flightPrices[destination.City]}");
                }
                if (hotelPrices.ContainsKey(destination.City))
                {
                    Console.WriteLine($"  Hotel Price per Night: ${hotelPrices[destination.City]}");
                }
            }
            Console.WriteLine($"\nTotal Budget: ${budget}");
        }
    }

    // Destination class to hold city and activities
    public class Destination
    {
        public string City { get; set; }
        public List<string> Activities { get; set; }

        public Destination(string city, List<string> activities)
        {
            City = city;
            Activities = activities;
        }
    }
}
