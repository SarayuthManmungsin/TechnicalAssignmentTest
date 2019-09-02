using Customer.Inquiry.Domain.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.Inquiry.BusinessLogic.Interface
{
    public interface IBusinessLogicBase<T> where T : class, IDomainBase
    {
        Task<IList<T>> GetList();
        Task<T> Get(int internalId);
        Task<T> Update(T item);
        Task<T> Save(T item);
        void Delete(int internalId);
    }
}
