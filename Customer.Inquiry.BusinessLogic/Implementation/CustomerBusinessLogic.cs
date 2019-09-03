using Customer.Inquiry.BusinessLogic.Interface;
using Customer.Inquiry.Domain.Interface;
using Customer.Inquiry.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.Inquiry.BusinessLogic.Implementation
{
    // only business logic implementation is allowed.
    public class CustomerBusinessLogic : ICustomerBusinessLogic
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ITransactionRepository _transactionRepository;

        public CustomerBusinessLogic(
            ICustomerRepository customerRepository,
            ITransactionRepository transactionRepository)
        {
            _customerRepository = customerRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<IInquiryCustomer> GetCustomer(IInquiryCriteria criteria)
        {
            IInquiryCustomer customer = await _customerRepository.GetCustomer(criteria);
            return customer;
        }

        public void Delete(long internalId)
        {
            _customerRepository.Delete(internalId);
        }

        public Task<IInquiryCustomer> Get(long internalId)
        {
            return _customerRepository.Get(internalId);
        }

        public Task<IList<IInquiryCustomer>> GetList()
        {
            return _customerRepository.GetList();
        }

        public Task<IInquiryCustomer> Save(IInquiryCustomer item)
        {
            return _customerRepository.Save(item);
        }

        public Task<IInquiryCustomer> Update(IInquiryCustomer item)
        {
            return _customerRepository.Update(item);
        }
    }
}
