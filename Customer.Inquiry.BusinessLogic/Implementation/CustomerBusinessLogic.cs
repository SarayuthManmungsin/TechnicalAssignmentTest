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

        public CustomerBusinessLogic(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ICustomer> GetCustomer(IInquiryCriteria criteria)
        {
            return await GetCustomer(criteria);
        }

        public void Delete(int internalId)
        {
            _customerRepository.Delete(internalId);
        }

        public Task<ICustomer> Get(int internalId)
        {
            return _customerRepository.Get(internalId);
        }

        public Task<IList<ICustomer>> GetList()
        {
            return _customerRepository.GetList();
        }

        public Task<ICustomer> Save(ICustomer item)
        {
            return _customerRepository.Save(item);
        }

        public Task<ICustomer> Update(ICustomer item)
        {
            return _customerRepository.Update(item);
        }
    }
}
