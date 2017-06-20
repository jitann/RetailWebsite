using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Retail.Business.Model;
using Retail.Business.Model.Bill;
using Retail.Business.Model.Customer;
using Retail.Business.Model.Rule;

namespace Retail.Test
{
    [TestClass]
    public class RetailTest
    {
        [TestMethod]
        public void InvoiceTest()
        {
            var item = new Item()
            {
                Amount = 100,
                Id = 1,
                ItemType = ItemType.Default,
                Name = "Choclate"
            };

            var items = new System.Collections.ObjectModel.Collection<Item>();

            items.Add(item);
            var invoice = new Invoice()
            {
                Items = items
            };

            var engine = new RuleEngine();
            var result = engine.CalculateBill(invoice);
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// 1. cholcate amount : 150
        /// Customer is Employee
        /// rules  applied
        /// 1. If the user is an employee of the store, he gets a 30% discount  : discount : 45, balance 105
        /// 2.If the user is an affiliate of the store, he gets a 10% discount : not applied
        /// 3 If the user has been a customer for over 2 years, he gets a 5% discount. :not applied
        /// 4 For every $100 on the bill, there would be a $ 5 discount (e.g. for $ 990, you get $ 45 as a discount). :discount 5$ ,balance 100
        /// </summary>
        [TestMethod]
        public void InvoiceSimpleTest()
        {
            var item = new Item()
            {
                Amount = 150,
                Id = 1,
                ItemType = ItemType.Default,
                Name = "Choclate"
            };

            var items = new System.Collections.ObjectModel.Collection<Item>();

            items.Add(item);
            var invoice = new Invoice()
            {
                Items = items,
                Customer = new Employee()
            };

            var engine = new RuleEngine();
            var result = engine.CalculateBill(invoice);
            Assert.AreEqual(result.TotalAmount,100);
        }
        /// <summary>
        /// 1. cholcate amount : 150
        /// 2 Groceries : 100
        /// Customer is Employee
        /// rules  applied
        /// 1. If the user is an employee of the store, he gets a 30% discount  : discount : 45, balance 205, rule is not applicable for groceries
        /// 2.If the user is an affiliate of the store, he gets a 10% discount : not applied
        /// 3 If the user has been a customer for over 2 years, he gets a 5% discount. :not applied
        /// 4 For every $100 on the bill, there would be a $ 5 discount (e.g. for $ 990, you get $ 45 as a discount). :discount 10$ ,balance 195
        /// </summary>
        [TestMethod]
        public void InvoiceSimpleGroceriesTest()
        {
            var item = new Item()
            {
                Amount = 150,
                Id = 1,
                ItemType = ItemType.Default,
                Name = "Choclate"
            };

            var item1 = new Item()
            {
                Amount = 100,
                Id = 1,
                ItemType = ItemType.Groceries,
                Name = "Atta"
            };

            var items = new System.Collections.ObjectModel.Collection<Item>();

            items.Add(item);
            items.Add(item1);
            var invoice = new Invoice()
            {
                Items = items,
                Customer = new Employee()
            };

            var engine = new RuleEngine();
            var result = engine.CalculateBill(invoice);
            Assert.AreEqual(result.TotalAmount, 195);
        }

        /// <summary>
        /// 1. cholcate amount : 150
        /// 2 Groceries : 100
        /// Customer is Affiliate
        /// rules  applied
        /// 1. If the user is an employee of the store, he gets a 30% discount  : discount : 15, balance 235, rule is not applicable for groceries
        /// 2.If the user is an affiliate of the store, he gets a 10% discount : not applied
        /// 3 If the user has been a customer for over 2 years, he gets a 5% discount. :not applied
        /// 4 For every $100 on the bill, there would be a $ 5 discount (e.g. for $ 990, you get $ 45 as a discount). :discount 10$ ,balance 225
        /// </summary>
        [TestMethod]
        public void InvoiceSimpleGroceriesAffiliateTest()
        {
            var item = new Item()
            {
                Amount = 150,
                Id = 1,
                ItemType = ItemType.Default,
                Name = "Choclate"
            };

            var item1 = new Item()
            {
                Amount = 100,
                Id = 1,
                ItemType = ItemType.Groceries,
                Name = "Atta"
            };

            var items = new System.Collections.ObjectModel.Collection<Item>();

            items.Add(item);
            items.Add(item1);
            var invoice = new Invoice()
            {
                Items = items,
                Customer = new Affiliate()
            };

            var engine = new RuleEngine();
            var result = engine.CalculateBill(invoice);
            Assert.AreEqual(result.TotalAmount, 225);
        }

        /// <summary>
        /// 1. cholcate amount : 150
        /// 2 Groceries : 100
        /// Customer is Affiliate and 2 years old
        /// rules  applied
        /// 1. If the user is an employee of the store, he gets a 30% discount  : discount : 15, balance 235, rule is not applicable for groceries
        /// 2.If the user is an affiliate of the store, he gets a 10% discount : not applied
        /// 3 If the user has been a customer for over 2 years, he gets a 5% discount. :not applied
        /// 4 For every $100 on the bill, there would be a $ 5 discount (e.g. for $ 990, you get $ 45 as a discount). :discount 10$ ,balance 225
        /// 5 If the user has been a customer for over 2 years, he gets a 5% discount.  : nto applied , since only one % rule can be applied
        /// </summary>
        [TestMethod]
        public void InvoiceSimpleGroceriesAffiliateTwoPlusYearsOldTest()
        {
            var item = new Item()
            {
                Amount = 150,
                Id = 1,
                ItemType = ItemType.Default,
                Name = "Choclate"
            };

            var item1 = new Item()
            {
                Amount = 100,
                Id = 1,
                ItemType = ItemType.Groceries,
                Name = "Atta"
            };

            var items = new System.Collections.ObjectModel.Collection<Item>();

            items.Add(item);
            items.Add(item1);
            var invoice = new Invoice()
            {
                Items = items,
                Customer = new Affiliate()
                {
                   IsLoyal = true
                }
            };

            var engine = new RuleEngine();
            var result = engine.CalculateBill(invoice);
            Assert.AreEqual(result.TotalAmount, 225);
        }

        /// <summary>
        /// 1. cholcate amount : 150
        /// 2 Groceries : 100
        /// Customer is Affiliate and 2 years old
        /// rules  applied
        /// 1. If the user has been a customer for over 2 years, he gets a 5% discount.  : discount : 7.5 , balance 242.5
        /// 2.If the user is an affiliate of the store, he gets a 10% discount : not applied
        /// 3 If the user has been a customer for over 2 years, he gets a 5% discount. :not applied
        /// 4 For every $100 on the bill, there would be a $ 5 discount (e.g. for $ 990, you get $ 45 as a discount). :discount 10$ ,balance 232.5
        /// </summary>
        [TestMethod]
        public void InvoiceSimpleGroceriesCustomerTwoPlusYearsOldTest()
        {
            var item = new Item()
            {
                Amount = 150,
                Id = 1,
                ItemType = ItemType.Default,
                Name = "Choclate"
            };

            var item1 = new Item()
            {
                Amount = 100,
                Id = 1,
                ItemType = ItemType.Groceries,
                Name = "Atta"
            };

            var items = new System.Collections.ObjectModel.Collection<Item>();

            items.Add(item);
            items.Add(item1);
            var invoice = new Invoice()
            {
                Items = items,
                Customer = new Customer()
                {
                    IsLoyal = true
                }
            };

            var engine = new RuleEngine();
            var result = engine.CalculateBill(invoice);
            Assert.AreEqual(result.TotalAmount,Convert.ToDecimal(232.5));
        }

        [TestMethod]
        public void InvoiceSimpleCustomer()
        {
            var item = new Item()
            {
                Amount = 100,
                Id = 1,
                ItemType = ItemType.Default,
                Name = "Choclate"
            };

      
            var items = new System.Collections.ObjectModel.Collection<Item>();

            items.Add(item);
            var invoice = new Invoice()
            {
                Items = items,
                Customer = new Customer()
            };

            var engine = new RuleEngine();
            var result = engine.CalculateBill(invoice);
            Assert.AreEqual(result.TotalAmount, Convert.ToDecimal(95));
        }
        /// <summary>
        /// No items in the cart.
        /// </summary>
        [TestMethod]
        public void NoItemsTest()
        {
           
            var invoice = new Invoice()
            {
           
            };

            var engine = new RuleEngine();
            var result = engine.CalculateBill(invoice);
            Assert.AreEqual(result.TotalAmount, 0);
        }

        //[TestMethod]
        //public void InvoiceSimpleGroceriesCustomerTwoPlusYearsOldTest()
        //{
        //    var item = new Item()
        //    {
        //        Amount = 150,
        //        Id = 1,
        //        ItemType = ItemType.Default,
        //        Name = "Choclate"
        //    };

        //    var item1 = new Item()
        //    {
        //        Amount = 100,
        //        Id = 1,
        //        ItemType = ItemType.Groceries,
        //        Name = "Atta"
        //    };

        //    var items = new System.Collections.ObjectModel.Collection<Item>();

        //    items.Add(item);
        //    items.Add(item1);
        //    var invoice = new Invoice()
        //    {
        //        Items = items,
        //        Customer = new Customer()
        //        {
        //            StartDate = DateTime.Now.AddMonths(26)
        //        }
        //    };

        //    var engine = new RuleEngine();
        //    var result = engine.CalculateBill(invoice);
        //    Assert.AreEqual(result.TotalAmount, 232.5);
        //}
    }
}