using Customer.Inquiry.Domain.Implementation;
using System;
using System.Data.Entity;

namespace Customer.Inquiry.DataAccess
{
    public interface ICustomerInquiryContext : IDisposable
    {
        DbSet<InquiryCustomer> Customers { get; set; }
        DbSet<Transaction> Transactions { get; set; }
    }
}
