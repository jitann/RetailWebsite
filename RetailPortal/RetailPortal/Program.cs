using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retail.Business.Model;
using Retail.Business.Model.Bill;
using Retail.Business.Model.Customer;
using Retail.Business.Model.Rule;

namespace RetailPortal
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = GetCustomer();
            if (customer == null)
            {
                customer = GetCustomer();
            }
            else if (customer != null)
            {
                var items = GetItems();

                var invoice = new Invoice()
                {
                    Customer = customer,
                    Items = items
                };
                var engine = new RuleEngine();
                var result = engine.CalculateBill(invoice);
                if (result != null)
                {
                    Console.WriteLine();
                    Console.WriteLine(string.Format("final Bill is {0}", result.TotalAmount));
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            Console.ReadLine();
        }

        private static Collection<Item> GetItems()
        {
            Console.WriteLine("Enter Items  as Name space Amount , if its grocery space 1 else 0");
            Console.WriteLine("Example");
            Console.WriteLine("Chocolate 100 0");
            Console.WriteLine("Rice 200 1");
            Console.WriteLine("Daal 150 1");
            Console.WriteLine("0");
            Console.WriteLine("when you are done enter 0");
            var stuffs = new Collection<Item>();
            while (true)
            {
                try
                {

                    var input = Console.ReadLine();

                    if (input == "0")
                        break;
                    var items = input.Split(' ');
                    var item = new Item()
                    {
                        Name = items[0],
                        Amount = Convert.ToDecimal(items[1]),
                        ItemType = items[2] == "0" ? ItemType.Default : ItemType.Groceries
                    };
                    stuffs.Add(item);
                }
                catch
                {
                    Console.WriteLine("Invalid input, please try again");
                }
            }
            return stuffs;
        }

        private static ICustomer GetCustomer()
        {
            try
            {
                Console.WriteLine(string.Format("Enter Customer type :  0 for customer  1 for employee  2 for affiliate  "));
                var customerType = Console.ReadLine();

                ICustomer customer = null;
                if (customerType == "0")
                {
                    customer = new Customer();
                }
                else if (customerType == "1")
                {
                    customer = new Employee();
                }
                else if (customerType == "2")
                {
                    customer = new Affiliate();
                }
                else
                {
                    Console.WriteLine("Invalid input , please try again");
                    return null;
                }
                Console.WriteLine("Has the user has been a customer for over 2 years? 0 or 1");
                string oldCustomer = Console.ReadLine();
                if (oldCustomer == "1")
                    customer.IsLoyal = true;
                else if (oldCustomer == "0")
                    customer.IsLoyal = false;
                else
                {
                    Console.WriteLine("Invalid input , please try again");
                    return null;
                }

                return customer;
            }
            catch
            {
                Console.WriteLine("Invalid input , please try again");
                return null;
            }
        }
    }
}
