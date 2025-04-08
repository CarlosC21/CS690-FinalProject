using System;

class Program
{
    static void Main(string[] args)
    {
        // Define the starting budget for the trip
        Console.WriteLine("Enter starting budget for the trip:");
        double startingBudget = Convert.ToDouble(Console.ReadLine());
        Budget tripBudget = new Budget(startingBudget);

        // Create a trip
        Console.WriteLine("Enter the trip name:");
        string tripName = Console.ReadLine();
        Console.WriteLine("Enter the start date (yyyy-mm-dd):");
        DateTime startDate = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Enter the end date (yyyy-mm-dd):");
        DateTime endDate = DateTime.Parse(Console.ReadLine());
        Trip myTrip = new Trip(tripName, startDate, endDate, startingBudget);

        // Add cities and activities
        bool addCities = true;
        while (addCities)
        {
            Console.WriteLine("\nEnter a city name for your trip:");
            string cityName = Console.ReadLine();
            City city = new City(cityName);

            bool addActivities = true;
            while (addActivities)
            {
                Console.WriteLine("Enter activity name for this city:");
                string activityName = Console.ReadLine();
                Console.WriteLine("Enter the cost of the activity:");
                double activityCost = Convert.ToDouble(Console.ReadLine());
                city.AddActivity(new Activity(activityName, activityCost));

                Console.WriteLine("Would you like to add another activity? (y/n)");
                string response = Console.ReadLine().ToLower();
                if (response != "y") addActivities = false;
            }

            myTrip.AddCity(city);

            Console.WriteLine("Would you like to add another city? (y/n)");
            string cityResponse = Console.ReadLine().ToLower();
            if (cityResponse != "y") addCities = false;
        }

        // Display the trip itinerary
        myTrip.DisplayItinerary();

        // Track expenses and update budget
        foreach (var city in myTrip.Cities)
        {
            foreach (var activity in city.Activities)
            {
                tripBudget.AddExpense(activity.Cost);
            }
        }

        // Display updated budget
        tripBudget.DisplayBudget();
    }
}
