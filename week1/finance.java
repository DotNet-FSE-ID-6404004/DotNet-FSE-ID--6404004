public class finance {

    public static double futureValue(double amount, double rate, int years) {
        if (years == 0) {
            return amount;
        }
        return futureValue(amount, rate, years - 1) * (1 + rate);
    }

    public static void main(String[] args) {
        double amount = 10000.0;
        double rate = 0.08;
        int years = 5;

        double result = futureValue(amount, rate, years);

        System.out.println("Financial Forecast:");
        System.out.println("Starting Amount: $" + amount);
        System.out.println("Annual Rate: " + (rate * 100) + "%");
        System.out.println("Years: " + years);
        System.out.printf("Predicted Value: $%.2f\n", result);
    }
}
