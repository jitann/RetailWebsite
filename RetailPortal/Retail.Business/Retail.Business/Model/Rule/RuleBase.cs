using System;
using System.Linq;
using Retail.Business.Model.Customer;

namespace Retail.Business.Model.Rule
{
    public abstract class RuleBase : IRule
    {
        /// <summary>
        /// Calculates the discount.
        /// </summary>
        /// <returns></returns>
        public abstract decimal CalculateDiscount(decimal amount, ICustomer customer);

        /// <summary>
        /// Calculates the discount amount.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        /// <returns></returns>
        public Invoice CalculateDiscountAmount(Invoice invoice)
        {
            if (invoice != null && invoice.Items != null && invoice.Items.Count > 0)
            {
                decimal groceryAmount = 0;
                decimal nonGroceryAmount = 0;
                invoice.TotalAmount =invoice.IsTotalAmountSet? invoice.TotalAmount: invoice.Items.Sum(c => c.Amount);

                if (!invoice.IsTotalAmountSet)
                {
                    Console.WriteLine("******************");
                    Console.WriteLine(string.Format("Total amount before applying discount {0} ", invoice.TotalAmount.ToString()));
                }
               
                if (this.RuleType == Rule.RuleType.PercentageRule)
                {
                    var nonGroceryItems = invoice.Items.Where(c => c.ItemType == Bill.ItemType.Groceries);
                    groceryAmount = nonGroceryItems.Sum(c => c.Amount);
                    nonGroceryAmount = invoice.TotalAmount - groceryAmount;
                }
                else
                {
                    nonGroceryAmount = invoice.TotalAmount;
                }
                //discount rule can be applied only once
                if (IsDiscountApplicable(invoice))
                {
                    
                    var discount = CalculateDiscount(nonGroceryAmount, invoice.Customer);
                    if (discount > 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine(string.Format("Applied discount for {0} and the discount is {1}", this.Description, discount.ToString()));
                    }
                    invoice.TotalAmount = invoice.TotalAmount - discount;
                }

                //set count of rules executed of each rule type
                SetRuleTypeCount(invoice);
                invoice.IsTotalAmountSet = true;
            }

            return invoice;
        }

        /// <summary>
        /// Determines whether [is discount applicable].
        /// </summary>
        /// <returns></returns>
        private bool IsDiscountApplicable(Invoice invoice)
        {
            if (this.RuleType == Rule.RuleType.PercentageRule && invoice.RulesExecuted.ContainsKey(this.RuleType) && invoice.RulesExecuted[this.RuleType] > 0)
                return false;

            return true;
        }

        /// <summary>
        /// Sets the rule type count.
        /// </summary>
        private void SetRuleTypeCount(Invoice invoice)
        {
            if (invoice.RulesExecuted.ContainsKey(this.RuleType))
            {
                var count = invoice.RulesExecuted[this.RuleType];
                invoice.RulesExecuted[this.RuleType] = ++count;
            }
            else
            {
                invoice.RulesExecuted[this.RuleType] = 1;
            }
        }

        /// <summary>
        /// Gets or sets the type of the rule.
        /// </summary>
        /// <value>
        /// The type of the rule.
        /// </value>
        public virtual RuleType RuleType
        {
            get
            {
                return Rule.RuleType.Default;
            }
        }

        public virtual string Description
        {
            get
            {
                return string.Empty;
            }
        }
    }
}