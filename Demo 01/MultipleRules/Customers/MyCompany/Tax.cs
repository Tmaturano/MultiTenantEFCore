namespace MultipleRules.Customers.MyCompany
{
    public class Tax : ITax
    {
        public decimal CalculateICMS(decimal value) => value * 2;
    }
}
