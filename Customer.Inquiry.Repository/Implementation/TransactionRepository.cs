using Customer.Inquiry.DataAccess;
using Customer.Inquiry.Domain.Interface;
using Customer.Inquiry.Repository.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

namespace Customer.Inquiry.Repository.Implementation
{
    public class TransactionRepository : ITransactionRepository
    {
        public async void Delete(int internalId)
        {
            using (var context = new CustomerInquiryContext())
            {
                var transaction = new Domain.Implementation.Transaction { Id = internalId };
                context.Transactions.Attach(transaction);
                context.Transactions.Remove(transaction);
                await context.SaveChangesAsync();
            }
        }

        public async Task<ITransaction> Get(int internalId)
        {
            using (var context = new CustomerInquiryContext())
            {
                return await context.Transactions.FindAsync(internalId);
            }
        }

        public async Task<IList<ITransaction>> GetList()
        {
            using (var context = new CustomerInquiryContext())
            {
                return await context.Transactions.ToListAsync();
            }
        }

        public async Task<ITransaction> Save(ITransaction item)
        {
            using (var context = new CustomerInquiryContext())
            {
                context.Transactions.AddOrUpdate(item);
                await context.SaveChangesAsync();
                return await Get(item.Id);
            }
        }

        public async Task<ITransaction> Update(ITransaction item)
        {
            return await Save(item);
        }
    }
}
