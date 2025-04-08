using System;

public class Budget
{
    public double StartingAmount { get; set; }
    public double RemainingAmount { get; set; }

    public Budget(double startingAmount)
    {
        StartingAmount = startingAmount;
        RemainingAmount = startingAmount;
    }

    public void AddExpense(double expense)
    {
        RemainingAmount -= expense;
        Console.WriteLine($"Expense Added: ${expense}. Remaining Budget: ${RemainingAmount}");
    }

    public void DisplayBudget()
    {
        Console.WriteLine($"Starting Budget: ${StartingAmount}");
        Console.WriteLine($"Remaining Budget: ${RemainingAmount}");
    }
}