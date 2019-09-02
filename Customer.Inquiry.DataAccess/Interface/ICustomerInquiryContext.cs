using Customer.Inquiry.Domain.Interface;
using System;
using System.Data.Entity;

namespace Customer.Inquiry.DataAccess
{
    public interface ICustomerInquiryContext : IDisposable
    {
        DbSet<ICustomer> Customers { get; set; }
        DbSet<ITransaction> Transactions { get; set; }
    }
}
