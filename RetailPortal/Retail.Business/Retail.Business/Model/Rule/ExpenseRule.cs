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

        public override string Description
        {
            get
            {
                return "For every $100 on the bill, there would be a $ 5 discount (e.g. for $ 990, you get $ 45 as a discount). ";
            }
        }
    }
}