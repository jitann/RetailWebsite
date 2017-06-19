using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Business.Model.Rule
{
    public static class RulesHelper
    {

        /// <summary>
        /// Gets the after rules.
        /// This can be dynamically injected using DI
        /// </summary>
        /// <returns></returns>
        public static Collection<IRule> GetBeforRules()
        {
            var rules =new Collection<IRule>();
            return rules;
        }


        public static Collection<IRule> GetAfterRules()
        {
            var rules = new Collection<IRule>();
            rules.Add(new LoyalityRule());
            rules.Add(new ExpenseRule());
            return rules;
        }
    }
}
