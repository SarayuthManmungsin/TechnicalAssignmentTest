using Customer.Inquiry.Domain.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Customer.Inquiry.Domain.Implementation
{
    public class Customer : DomainUser, ICustomer
    {
        [MaxLength(5)]
        public virtual IEnumerable<ITransaction> Transactions { get; set; }
    }
}
