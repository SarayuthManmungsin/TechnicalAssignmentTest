using Customer.Inquiry.Domain.Interface;
using System.Collections.Generic;

namespace Customer.Inquiry.Domain.Implementation
{
    public class Customer : DomainUser, ICustomer
    {
        public virtual IEnumerable<ITransaction> Transactions { get; set; }
    }
}
