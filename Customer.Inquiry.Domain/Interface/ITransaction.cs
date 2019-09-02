using Customer.Inquiry.Domain.Enum;

namespace Customer.Inquiry.Domain.Interface
{
    public interface ITransaction : IDomainBase
    {
        float Amount { get; set; }
        string CurrencyCode { get; set; }
        TransactionStatus Status { get; set; }
    }
}
