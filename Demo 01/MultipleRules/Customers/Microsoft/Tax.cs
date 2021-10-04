namespace MultipleRules.Customers.Microsoft
{
    public class Tax : ITax
    {
        public decimal CalculateICMS(decimal value) => value * 4;
    }
}
