using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retail.Business.Model.Customer;

namespace Retail.Business.Model.Rule
{
    public class EmployeeRule : RuleBase
    {
        /// <summary>
        /// Calculates the discount.
        /// </summary>
        /// <param name="bill">The bill.</param>
        /// <returns></returns>
        public override decimal CalculateDiscount(decimal amount,ICustomer customer)
        {
            return amount * 3 / 10;
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
        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public override string Description
        {
            get
            {
                return "If the user is an employee of the store, he gets a 30% discount  ";
            }
        }
    }
}
