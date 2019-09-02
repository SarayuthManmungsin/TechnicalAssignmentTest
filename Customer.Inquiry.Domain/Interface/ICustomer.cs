using System.Collections.Generic;

namespace Customer.Inquiry.Domain.Interface
{
    public interface ICustomer : IDomainUser
    {
        IEnumerable<ITransaction> Transactions { get; set; }
    }
}
