using Customer.Inquiry.Domain.Interface;
using System.Data.Entity;

namespace Customer.Inquiry.DataAccess
{
    public class CustomerInquiryContext : DbContext
    {
        public DbSet<IDomainUser> DomainUsers { get; set; }
        public DbSet<IHistory> IHistories { get; set; }
        public DbSet<IInquiryCriteria> InquiryCriterias { get; set; }
        public DbSet<ITransaction> Transactions { get; set; }
    }
}
