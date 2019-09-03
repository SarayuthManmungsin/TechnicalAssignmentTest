using System.Collections.Generic;

namespace Customer.Inquiry.Domain.Interface
{
    public interface IInquiryCustomer : IDomainUser
    {
        IEnumerable<ITransaction> Transactions { get; set; }
    }
}
