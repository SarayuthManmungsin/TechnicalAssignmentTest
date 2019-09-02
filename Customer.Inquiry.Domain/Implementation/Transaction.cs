using Customer.Inquiry.Domain.Enum;
using Customer.Inquiry.Domain.Interface;
using Customer.Inquiry.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace Customer.Inquiry.Domain.Implementation
{
    public class Transaction : DomainBase, IDomainBase, ITransaction
    {
        public Transaction()
        {
            Date = DateTime.Now.ToUnixTimestamp();
        }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public virtual decimal Amount { get; set; }

        public virtual string CurrencyCode { get; set; }

        public virtual TransactionStatus Status { get; set; }
        
        public virtual long Date { get; set; }
    }
}
