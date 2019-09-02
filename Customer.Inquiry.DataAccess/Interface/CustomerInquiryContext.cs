using Customer.Inquiry.Domain.Interface;
using System.Data.Entity;

namespace Customer.Inquiry.DataAccess
{
    public class CustomerInquiryContext : DbContext, ICustomerInquiryContext
    {
        public DbSet<ICustomer> Customers { get; set; }
        public DbSet<IHistory> Histories { get; set; }
        public DbSet<IInquiryCriteria> InquiryCriterias { get; set; }
        public DbSet<ITransaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ICustomer>().HasIndex(c => c.ContactEmail).IsUnique();
        }
    }
}
