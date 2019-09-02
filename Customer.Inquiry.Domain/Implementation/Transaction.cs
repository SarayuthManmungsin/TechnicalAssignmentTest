using Customer.Inquiry.Domain.Enum;
using Customer.Inquiry.Domain.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer.Inquiry.Domain.Implementation
{
    public class Transaction : DomainBase, IDomainBase, ITransaction
    {
        [MaxLength(10)]
        public virtual int TransactionId { get; set; }
        [Column(TypeName = "decimal(16,2)")]
        public virtual decimal Amount { get; set; }
        [DataType(DataType.Currency)]
        public virtual string CurrencyCode { get; set; }
        public virtual TransactionStatus Status { get; set; }
    }
}
