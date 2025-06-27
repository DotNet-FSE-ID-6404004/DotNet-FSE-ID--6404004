using System;

public class Finance
{
    public static double FutureValue(double amount, double rate, int years)
    {
        if (years == 0)
        {
            return amount;
        }
        return FutureValue(amount, rate, years - 1) * (1 + rate);
    }

    public static void Main()
    {
        double amount = 10000.0;
        double rate = 0.08;
        int years = 5;

        double result = FutureValue(amount, rate, years);

        Console.WriteLine("Financial Forecast:");
        Console.WriteLine($"Starting Amount: ${amount}");
        Console.WriteLine($"Annual Rate: {rate * 100}%");
        Console.WriteLine($"Years: {years}");
        Console.WriteLine($"Predicted Value: ${result:F2}");
    }
}
