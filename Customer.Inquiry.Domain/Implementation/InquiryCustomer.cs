using Customer.Inquiry.Domain.Interface;
using System.Collections.Generic;

namespace Customer.Inquiry.Domain.Implementation
{
    public class InquiryCustomer : DomainUser, IInquiryCustomer
    {
        public InquiryCustomer()
        {
            Transactions = new List<Transaction>();
        }

        public virtual IList<Transaction> Transactions { get; set; }
    }
}
