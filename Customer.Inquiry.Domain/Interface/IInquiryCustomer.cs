using Customer.Inquiry.Domain.Implementation;
using System.Collections.Generic;

namespace Customer.Inquiry.Domain.Interface
{
    public interface IInquiryCustomer : IDomainUser
    {
        IList<Transaction> Transactions { get; set; }
    }
}
