using Customer.Inquiry.Domain.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.Inquiry.Repository.Interface
{
    public interface IRepositoryBase<T>
    {
        Task<IList<T>> GetList();
        Task<T> Get(long internalId);
        Task<T> Update(T item);
        Task<T> Save(T item);
        void Delete(long internalId);
    }
}
