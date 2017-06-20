using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Business.Model.Customer
{
    /// <summary>
    /// Customer
    /// </summary>
    public class Customer :ICustomer
    {
        public string Name
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        }

        public virtual decimal CalculateBill()
        {
            return 0;
        }

        public bool IsLoyal { get; set; }
    }
}
