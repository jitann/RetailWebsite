using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retail.Business.Model.Bill;
using Retail.Business.Model.Customer;
using Retail.Business.Model.Rule;

namespace Retail.Business.Model
{
    public class Invoice
    {
        /// <summary>
        /// The customer
        /// </summary>
        public ICustomer Customer;

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
       public Collection<Item> Items { get; set; }

       /// <summary>
       /// Gets or sets the total amount.
       /// </summary>
       /// <value>
       /// The total amount.
       /// </value>
       public Decimal TotalAmount { get; set; }

       /// <summary>
       /// The rules executed
       /// </summary>
       public ConcurrentDictionary<RuleType, int> RulesExecuted = new ConcurrentDictionary<RuleType, int>();


       /// <summary>
       /// Gets or sets a value indicating whether this instance is total amount set.
       /// </summary>
       /// <value>
       /// <c>true</c> if this instance is total amount set; otherwise, <c>false</c>.
       /// </value>
       public bool IsTotalAmountSet { get; set; }
    }
}
