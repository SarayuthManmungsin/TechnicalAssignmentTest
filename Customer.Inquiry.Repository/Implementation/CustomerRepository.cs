using Customer.Inquiry.DataAccess;
using Customer.Inquiry.Domain.Interface;
using Customer.Inquiry.Repository.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

namespace Customer.Inquiry.Repository.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        public async void Delete(int internalId)
        {
            using (var context = new CustomerInquiryContext())
            {
                var customer = new Domain.Implementation.Customer { Id = internalId };
                context.Customers.Attach(customer);
                context.Customers.Remove(customer);
                await context.SaveChangesAsync();
            }
        }

        public async Task<ICustomer> Get(int internalId)
        {
            using (var context = new CustomerInquiryContext())
            {
                return await context.Customers.FindAsync(internalId);
            }
        }

        public async Task<IList<ICustomer>> GetList()
        {
            using (var context = new CustomerInquiryContext())
            {
                return await context.Customers.ToListAsync();
            }
        }

        public async Task<ICustomer> Save(ICustomer item)
        {
            using (var context = new CustomerInquiryContext())
            {
                context.Customers.AddOrUpdate(item);
                await context.SaveChangesAsync();
                return await Get(item.Id);
            }
        }

        public async Task<ICustomer> Update(ICustomer item)
        {
            return await Save(item);
        }
    }
}
