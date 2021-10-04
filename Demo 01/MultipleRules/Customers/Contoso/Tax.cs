namespace MultipleRules.Customers.Contoso
{
    public class Tax : ITax
    {
        public decimal CalculateICMS(decimal value) => value * 3;
    }
}
