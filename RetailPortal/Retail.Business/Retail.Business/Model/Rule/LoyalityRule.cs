using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retail.Business.Model.Customer;

namespace Retail.Business.Model.Rule
{
    public class LoyalityRule : RuleBase
    {

        /// <summary>
        /// Calculates the discount.
        /// </summary>
        /// <param name="bill">The bill.</param>
        /// <returns></returns>
        public override decimal CalculateDiscount(decimal amount, ICustomer customer)
        {
            if (customer != null && customer.IsLoyal)
                return amount * 5 / 100;
            return 0;
        }

        /// <summary>
        /// Gets the type of the rule.
        /// </summary>
        /// <value>
        /// The type of the rule.
        /// </value>
        public override RuleType RuleType
        {
            get
            {
                return RuleType.PercentageRule;
            }
        }

        public override string Description
        {
            get
            {
                return "If the user has been a customer for over 2 years, he gets a 5% discount. ";
            }
        }
    }
}
