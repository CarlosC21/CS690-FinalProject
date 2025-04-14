using System;
using System.Collections.Generic;

public class City
{
    public string Name { get; set; }
    public string Country { get; set; }
    public List<Activity> Activities { get; set; }
    public double AccommodationCost { get; set; }

    public City(string name, string country)
    {
        Name = name;
        Country = country;
        Activities = new List<Activity>();
        AccommodationCost = 0;
    }

    public void AddActivity(Activity activity)
    {
        Activities.Add(activity);
    }
}
