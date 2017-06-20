using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retail.Business.Model.Customer;

namespace Retail.Business.Model.Rule
{
    /// <summary>
    /// IRule
    /// </summary>
    public interface IRule
    {
        /// <summary>
        /// Calculates the discount.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        /// <returns></returns>
        decimal CalculateDiscount(decimal amount,ICustomer customer);
        
        /// <summary>
        /// Calculates the discount amount.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        /// <returns></returns>
        Invoice CalculateDiscountAmount(Invoice invoice);

        /// <summary>
        /// Gets or sets the type of the rule.
        /// </summary>
        /// <value>
        /// The type of the rule.
        /// </value>
        RuleType RuleType { get; }

        string Description { get; }
    }
}
