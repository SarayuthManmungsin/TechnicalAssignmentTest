using Customer.Inquiry.Domain.Enum;
using Customer.Inquiry.Domain.Interface;
using Customer.Inquiry.Utils;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer.Inquiry.Domain.Implementation
{
    public class Transaction : DomainBase, IDomainBase, ITransaction
    {
        public Transaction()
        {
            Date = DateTime.Now.ToUnixTimestamp();
        }

        public virtual int TransactionId { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public virtual double Amount { get; set; }

        public virtual string CurrencyCode { get; set; }

        public virtual TransactionStatus Status { get; set; }

        public virtual long Date { get; set; }

        public virtual InquiryCustomer Customer { get; set; }
    }
}
