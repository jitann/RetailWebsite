using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Business.Model.Customer
{
    /// <summary>
    /// Employee
    /// </summary>
    public class Employee :Customer
    {
        /// <summary>
        /// Calculates the bill.
        /// </summary>
        /// <returns></returns>
        public override decimal CalculateBill()
        {
            return base.CalculateBill();
        }
    }
}

