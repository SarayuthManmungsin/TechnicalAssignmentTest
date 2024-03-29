﻿using Customer.Inquiry.Domain.Enum;
using Customer.Inquiry.Domain.Implementation;
using Customer.Inquiry.Domain.Interface;
using Customer.Inquiry.Utils;
using System.ComponentModel.DataAnnotations;

namespace Customer.Inquiry.ViewModel
{
    public class TransactionViewmodel
    {
        public TransactionViewmodel() { }

        public TransactionViewmodel(ITransaction transaction)
        {
            id = transaction.TransactionId;
            date = transaction.Date.FromUnixTimestamp().ToString(Extension.DATE_FORMAT);
            amount = transaction.Amount.ToString();
            currency = transaction.CurrencyCode;
            status = transaction.Status.ToString();
        }

        public int id { get; set; }

        public string date { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public string amount { get; set; }

        public string currency { get; set; }

        public string status { get; set; }

        public Transaction Convert()
        {
            return new Transaction
            {
                Amount = double.Parse(amount),
                CurrencyCode = currency,
                Status = status.AsEnum<TransactionStatus>(),
                TransactionId = id
            };
        }
    }
}
