using System;
using Retail.Business.Model.Customer;

namespace Retail.Business.Model.Rule
{
    public class AffiliateRule : RuleBase
    {
        public override decimal CalculateDiscount(decimal amount, ICustomer customer)
        {
            return amount * 1 / 10;
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
                return "If the user is an affiliate of the store, he gets a 10% discount ";
            }
        }
    }
}