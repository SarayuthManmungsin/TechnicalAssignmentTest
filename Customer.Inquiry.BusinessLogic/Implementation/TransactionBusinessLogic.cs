using Customer.Inquiry.BusinessLogic.Interface;
using Customer.Inquiry.Domain.Interface;
using Customer.Inquiry.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.Inquiry.BusinessLogic.Implementation
{
    // only business logic implementation is allowed.
    public class TransactionBusinessLogic : ITransactionBusinessLogic
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionBusinessLogic(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void Delete(int internalId)
        {
            _transactionRepository.Delete(internalId);
        }

        public Task<ITransaction> Get(int internalId)
        {
            return _transactionRepository.Get(internalId);
        }

        public Task<IList<ITransaction>> GetList()
        {
            return _transactionRepository.GetList();
        }

        public Task<ITransaction> Save(ITransaction item)
        {
            return _transactionRepository.Save(item);
        }

        public Task<ITransaction> Update(ITransaction item)
        {
            return _transactionRepository.Update(item);
        }
    }
}
