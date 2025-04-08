using System;
using System.Collections.Generic;

public class City
{
    public string Name { get; set; }
    public List<Activity> Activities { get; set; }

    public City(string name)
    {
        Name = name;
        Activities = new List<Activity>();
    }

    public void AddActivity(Activity activity)
    {
        Activities.Add(activity);
    }

    public void DisplayCityDetails()
    {
        Console.WriteLine($"\nCity: {Name}");
        foreach (var activity in Activities)
        {
            activity.DisplayActivityDetails();
        }
    }
}
