namespace AvaItineraryPlanner
{
    public class Budget
    {
        public decimal TotalBudget { get; set; }
        public decimal DailyBudget { get; set; }

        public Budget(decimal totalBudget, decimal dailyBudget)
        {
            TotalBudget = totalBudget;
            DailyBudget = dailyBudget;
        }
    }
}
