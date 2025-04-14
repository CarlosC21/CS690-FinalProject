using System;
using System.Collections.Generic;

namespace AvaItineraryPlanner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Ava's Itinerary Planner!");

            // Get starting budget
            Console.Write("Enter your starting budget: ");
            decimal budget = decimal.Parse(Console.ReadLine());

            // Ask for country once
            Console.Write("Enter the country you're planning to visit: ");
            string country = Console.ReadLine();

            List<City> cities = new List<City>();
            decimal totalAccommodationCost = 0;
            decimal totalActivityCost = 0;

            bool addMoreCities = true;

            while (addMoreCities)
            {
                Console.Write($"\nEnter a city name in {country}: ");
                string cityName = Console.ReadLine();

                Console.Write($"Enter the number of days you plan to stay in {cityName}: ");
                int days = int.Parse(Console.ReadLine());

                Console.Write($"Enter the total accommodation cost for your stay in {cityName}: ");
                decimal accommodationCost = decimal.Parse(Console.ReadLine());

                totalAccommodationCost += accommodationCost;

                // Activities input with costs
                List<Activity> activities = new List<Activity>();
                bool addMoreActivities = true;
                Console.WriteLine($"Enter activities you plan to do in {cityName}:");
                while (addMoreActivities)
                {
                    Console.Write("- Activity: ");
                    string activityName = Console.ReadLine();

                    Console.Write($"  Enter the cost of {activityName}: ");
                    decimal activityCost = decimal.Parse(Console.ReadLine());

                    activities.Add(new Activity { Name = activityName, Cost = activityCost });

                    totalActivityCost += activityCost;

                    Console.Write("Add another activity? (y/n): ");
                    string activityResponse = Console.ReadLine().ToLower();
                    addMoreActivities = activityResponse == "y";
                }

                cities.Add(new City
                {
                    Name = cityName,
                    Days = days,
                    AccommodationCost = accommodationCost,
                    Activities = activities
                });

                Console.Write("Would you like to add another city? (y/n): ");
                string cityResponse = Console.ReadLine().ToLower();
                addMoreCities = cityResponse == "y";
            }

            // Summary
            Console.WriteLine("\nHere’s your itinerary:");
            foreach (var city in cities)
            {
                Console.WriteLine($"\n- {city.Name} ({city.Days} days)");
                Console.WriteLine($"  Accommodation Cost: ${city.AccommodationCost}");
                Console.WriteLine("  Activities:");
                foreach (var activity in city.Activities)
                {
                    Console.WriteLine($"    • {activity.Name} - ${activity.Cost}");
                }
            }

            decimal totalCost = totalAccommodationCost + totalActivityCost;
            decimal remainingBudget = budget - totalCost;

            Console.WriteLine($"\nTotal Accommodation Cost: ${totalAccommodationCost}");
            Console.WriteLine($"Total Activity Cost: ${totalActivityCost}");
            Console.WriteLine($"Total Trip Cost: ${totalCost}");
            Console.WriteLine($"Remaining Budget: ${remainingBudget}");

            Console.WriteLine("\nSafe travels!");
        }
    }

    class City
    {
        public string Name { get; set; }
        public int Days { get; set; }
        public decimal AccommodationCost { get; set; }
        public List<Activity> Activities { get; set; }
    }

    class Activity
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
    }
}
