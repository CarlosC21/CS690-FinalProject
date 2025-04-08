using System;

public class Activity
{
    public string Name { get; set; }
    public double Cost { get; set; }

    public Activity(string name, double cost)
    {
        Name = name;
        Cost = cost;
    }

    public void DisplayActivityDetails()
    {
        Console.WriteLine($"- {Name} ($ {Cost})");
    }
}
