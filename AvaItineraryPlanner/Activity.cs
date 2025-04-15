public class Activity
{
    public string Name { get; set; }
    public decimal Cost { get; set; }
    public int Duration { get; set; }

    public Activity(string name, decimal cost)
    {
        Name = name;
        Cost = cost;
    }
}
