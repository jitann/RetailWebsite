using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Business.Model.Customer
{
    /// <summary>
    /// ICustomer
    /// </summary>
    public interface ICustomer
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        /// <summary>
        /// Calculates the bill.
        /// </summary>
        /// <returns></returns>
        decimal CalculateBill();

        bool IsLoyal { get; set; }
    }
}
