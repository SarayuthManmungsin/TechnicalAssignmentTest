using Customer.Inquiry.Domain.Enum;
using Customer.Inquiry.Domain.Interface;

namespace Customer.Inquiry.Domain.Implementation
{
    public class Transaction : DomainBase, IDomainBase, ITransaction
    {
        public virtual float Amount { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual TransactionStatus Status { get; set; }
    }
}
