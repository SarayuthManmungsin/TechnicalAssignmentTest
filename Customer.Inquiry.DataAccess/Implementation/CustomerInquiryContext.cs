using Customer.Inquiry.Domain.Implementation;
using System.Data.Entity;

namespace Customer.Inquiry.DataAccess
{
    public class CustomerInquiryContext : DbContext, ICustomerInquiryContext
    {
        public CustomerInquiryContext() : base("name=CustomerInquiryConnectionString")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<CustomerInquiryContext>());
        }

        public DbSet<InquiryCustomer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InquiryCustomer>().HasIndex(c => c.Email).IsUnique();
            modelBuilder.Entity<InquiryCustomer>().HasMany(t => t.Transactions);
        }
    }
}
