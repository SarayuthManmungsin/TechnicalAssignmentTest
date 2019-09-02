using Customer.Inquiry.Domain.Interface;
using System.Threading.Tasks;

namespace Customer.Inquiry.BusinessLogic.Interface
{
    public interface ICustomerBusinessLogic : IBusinessLogicBase<ICustomer>
    {
        Task<ICustomer> GetCustomer(IInquiryCriteria criteria);
    }
}
