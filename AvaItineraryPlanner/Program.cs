using System;
using System.Collections.Generic;

namespace AvaItineraryPlanner
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Get trip name and budget
            Console.Write("Enter the name of your trip: ");
            string tripName = Console.ReadLine();

            Console.Write("Enter your starting budget for the trip (in dollars): ");
            decimal startingBudget = decimal.Parse(Console.ReadLine());

            // Step 2: Ask for the starting date of the trip
            Console.Write("\nEnter the start date of your trip (yyyy-mm-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            // Step 3: Initialize trip-related variables
            decimal totalAccommodationCost = 0;
            decimal totalFlightCost = 0;
            decimal totalActivityCost = 0;
            DateTime tripEndDate = startDate;

            List<City> cities = new List<City>();

            // Step 4: Loop to allow adding multiple countries
            bool addAnotherCountry = true;
            while (addAnotherCountry)
            {
                // Step 5: Ask for the country
                Console.Write("Enter the country you are visiting: ");
                string country = Console.ReadLine();

                // Step 6: Ask for the number of cities in the country
                Console.Write("How many cities would you like to visit in " + country + "? ");
                int numCities = int.Parse(Console.ReadLine());

                for (int i = 1; i <= numCities; i++)
                {
                    Console.WriteLine($"\nEnter details for city #{i} in {country}:");

                    // Step 7: Get city details
                    Console.Write("City Name: ");
                    string cityName = Console.ReadLine();

                    Console.Write("How many days will you stay in this city? ");
                    int daysInCity = int.Parse(Console.ReadLine());

                    // Calculate new trip end date based on the number of days
                    tripEndDate = tripEndDate.AddDays(daysInCity);

                    Console.Write("Enter the type of accommodation (e.g., hotel, Airbnb, etc.): ");
                    string accommodation = Console.ReadLine();

                    Console.Write("Enter the accommodation cost per night (in dollars): ");
                    decimal accommodationCost = decimal.Parse(Console.ReadLine());

                    Console.Write("Enter the flight cost (in dollars): ");
                    decimal flightCost = decimal.Parse(Console.ReadLine());

                    // Step 8: Ask for activities in the city
                    List<Activity> activities = new List<Activity>();
                    Console.Write($"How many activities will you do in {cityName}? ");
                    int numActivities = int.Parse(Console.ReadLine());

                    for (int j = 1; j <= numActivities; j++)
                    {
                        Console.WriteLine($"Enter details for activity #{j} in {cityName}:");

                        Console.Write("Activity Name: ");
                        string activityName = Console.ReadLine();

                        Console.Write("Activity Cost (in dollars): ");
                        decimal activityCost = decimal.Parse(Console.ReadLine());

                        activities.Add(new Activity(activityName, activityCost));
                    }

                    // Add city to the list
                    cities.Add(new City(cityName, country, daysInCity, accommodation, accommodationCost, flightCost, activities));

                    // Add to total cost
                    totalAccommodationCost += accommodationCost * daysInCity;
                    totalFlightCost += flightCost;
                    foreach (var activity in activities)
                    {
                        totalActivityCost += activity.Cost;
                    }
                }

                // Ask if user wants to add another country
                Console.Write("Would you like to add another country? (yes/no): ");
                string addCountryResponse = Console.ReadLine();
                addAnotherCountry = addCountryResponse.ToLower() == "yes";
            }

            // Step 9: Create the trip object
            Trip trip = new Trip(tripName, startingBudget, cities, startDate, tripEndDate);

            // Step 10: Display the trip details
            DisplayTripDetails(trip, totalAccommodationCost, totalFlightCost, totalActivityCost);
        }

        // Method to display trip details
        static void DisplayTripDetails(Trip trip, decimal totalAccommodationCost, decimal totalFlightCost, decimal totalActivityCost)
        {
            Console.WriteLine($"\n\nTrip Name: {trip.Name}");
            Console.WriteLine($"Trip Dates: {trip.StartDate.ToShortDateString()} - {trip.EndDate.ToShortDateString()}");
            Console.WriteLine($"Starting Budget: ${trip.Budget}");

            Console.WriteLine("\nCities in your trip:");
            foreach (var city in trip.Cities)
            {
                Console.WriteLine($"- {city.Name}, {city.Country}");
                Console.WriteLine($"  Days: {city.Days}, Accommodation: {city.Accommodation} (${city.AccommodationCost}/night), Flight Cost: ${city.FlightCost}");

                foreach (var activity in city.Activities)
                {
                    Console.WriteLine($"    - Activity: {activity.Name}, Cost: ${activity.Cost}");
                }
            }

            decimal totalCost = totalAccommodationCost + totalFlightCost + totalActivityCost;

            Console.WriteLine("\nTrip Summary:");
            Console.WriteLine($"Total Accommodation Cost: ${totalAccommodationCost}");
            Console.WriteLine($"Total Flight Cost: ${totalFlightCost}");
            Console.WriteLine($"Total Activity Cost: ${totalActivityCost}");
            Console.WriteLine($"Total Trip Cost: ${totalCost}");

            decimal finalBudget = trip.Budget - totalCost;
            Console.WriteLine($"\nYour final budget after expenses: ${finalBudget}");

            if (finalBudget >= 0)
            {
                Console.WriteLine("\nYou are within budget!");
            }
            else
            {
                Console.WriteLine("\nYou have exceeded your budget!");
            }
        }
    }
}
