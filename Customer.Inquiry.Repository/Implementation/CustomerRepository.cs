using Customer.Inquiry.DataAccess;
using Customer.Inquiry.Domain.Implementation;
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
                var customer = new InquiryCustomer { Id = internalId };
                context.Customers.Attach(customer);
                context.Customers.Remove(customer);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IInquiryCustomer> Get(int internalId)
        {
            using (var context = new CustomerInquiryContext())
            {
                return await context.Customers.FirstOrDefaultAsync(x => x.Id == internalId);
            }
        }

        public async Task<IInquiryCustomer> GetCustomer(IInquiryCriteria criteria)
        {
            using (var context = new CustomerInquiryContext())
            {
                return await context.Customers.Include(x => x.Transactions).FirstOrDefaultAsync(x => x.Id == criteria.CustomerId || x.Email == criteria.Email);
            }
        }

        public async Task<IList<IInquiryCustomer>> GetList()
        {
            using (var context = new CustomerInquiryContext())
            {
                return await context.Customers.Include(x => x.Transactions).ToListAsync<IInquiryCustomer>();
            }
        }

        public async Task<IInquiryCustomer> Save(IInquiryCustomer item)
        {
            using (var context = new CustomerInquiryContext())
            {
                context.Customers.AddOrUpdate(item as InquiryCustomer);
                context.SaveChanges();
            }

            return await Get(item.Id);
        }

        public async Task<IInquiryCustomer> Update(IInquiryCustomer item)
        {
            return await Save(item);
        }
    }
}
