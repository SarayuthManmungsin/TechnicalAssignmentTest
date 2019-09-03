using Customer.Inquiry.Domain.Interface;
using System.Threading.Tasks;

namespace Customer.Inquiry.Repository.Interface
{
    public interface ICustomerRepository : IRepositoryBase<IInquiryCustomer>
    {
        Task<IInquiryCustomer> GetCustomer(IInquiryCriteria criteria);
    }
}
