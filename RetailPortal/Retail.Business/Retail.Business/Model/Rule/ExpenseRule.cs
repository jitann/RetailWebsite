using System;
using Retail.Business.Model.Customer;

namespace Retail.Business.Model.Rule
{
    public class ExpenseRule : RuleBase
    {
        /// <summary>
        /// Calculates the discount.
        /// </summary>
        /// <param name="bill">The bill.</param>
        /// <returns></returns>
        public override decimal CalculateDiscount(decimal amount, ICustomer customer)
        {
            int discountCount = Convert.ToInt32(amount / 100);
            return discountCount * 5;
        }
    }
}