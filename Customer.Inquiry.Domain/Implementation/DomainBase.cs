using Customer.Inquiry.Domain.Interface;
using System.ComponentModel.DataAnnotations;

namespace Customer.Inquiry.Domain.Implementation
{
    public abstract class DomainBase : IDomainBase
    {
        public DomainBase()
        {
            Created = new History();
        }

        public DomainBase(IDomainUser user)
        {
            Created = new History(user);
        }

        [Key]
        [MaxLength(10)]
        public virtual int Id { get; set; }
        public virtual IHistory Created { get; set; }
        public virtual IHistory Updated { get; set; }
    }
}
