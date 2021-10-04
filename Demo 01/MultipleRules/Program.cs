using MultipleRules.Customers;
using System;

namespace MultipleRules
{
    // OOP and multiple business rules
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new Factory();

            var customeTax = factory.Create("microsoft");
            var amount = customeTax.CalculateICMS(10);

            Console.WriteLine(amount);
        }
    }

    // Good: Factory Method to create the instance of the class, with specific business rules for each client (by tenant_id, company_id of each client, etc.
    public class Factory
    {
        public ITax Create(string type) =>
            type.ToLower() switch
            {
                "mycompany" => new Customers.MyCompany.Tax(),
                "microsoft" => new Customers.Microsoft.Tax(),
                "contoso" => new Customers.Contoso.Tax(),
                _ => throw new ArgumentException("Invalid type", "type")
            };
    }

    // BAD Example (but most common viewed in applications)
    // Multiple IFs, each IF represents an unit test, so multiple tests for a single method and can become very complex with multiple lines of code.
    public static class Tax
    {
        public static decimal CalculateICMS(string client, decimal value)
        {
            if (client.ToLower() == "mycompany")
                return value * 2;

            if (client.ToLower() == "microsoft")
                return value * 3;

            if (client.ToLower() == "contoso")
                return value * 4;

            return value;
        }
    }
}
