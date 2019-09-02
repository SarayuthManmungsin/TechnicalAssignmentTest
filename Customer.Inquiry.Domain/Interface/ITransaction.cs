using Customer.Inquiry.Domain.Enum;

namespace Customer.Inquiry.Domain.Interface
{
    public interface ITransaction : IDomainBase
    {
        int TransactionId { get; set; }
        decimal Amount { get; set; }
        string CurrencyCode { get; set; }
        TransactionStatus Status { get; set; }
    }
}
