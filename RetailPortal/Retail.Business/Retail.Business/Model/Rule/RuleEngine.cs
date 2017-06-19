using System.Collections.Concurrent;
using Retail.Business.Model.Customer;

namespace Retail.Business.Model.Rule
{
    /// <summary>
    /// RuleEngine
    /// </summary>
    public class RuleEngine
    {

        public  ConcurrentDictionary<RuleType, int> RulesExecuted = new ConcurrentDictionary<RuleType, int>();

        /// <summary>
        /// Gets the rule. We can load this based on DI dynacmially instead of if , e
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns></returns>
        public  IRule GetRule(ICustomer customer)
        {
            if (customer is Employee)
                return new EmployeeRule();
            else if (customer is Affiliate)
                return new AffiliateRule();

            return null;
        }

        /// <summary>
        /// Processes the rules.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        /// <returns></returns>
        public  Invoice CalculateBill(Invoice invoice)
        {
            var beforeRules = RulesHelper.GetBeforRules();
            invoice = ApplyRules(invoice, beforeRules);

            var rule = GetRule(invoice.Customer);
            if (rule != null)
            {
                invoice = rule.CalculateDiscountAmount(invoice);
            }

            var afterRules = RulesHelper.GetAfterRules();
            invoice = ApplyRules(invoice, afterRules);
            return invoice;
        }

        /// <summary>
        /// Applies the rules.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        /// <param name="rules">The rules.</param>
        /// <returns></returns>
        private  Invoice ApplyRules(Invoice invoice, System.Collections.ObjectModel.Collection<IRule> rules)
        {
            foreach (var rule in rules)
            {
                invoice = rule.CalculateDiscountAmount(invoice);
            }

            return invoice;
        }
    }
}