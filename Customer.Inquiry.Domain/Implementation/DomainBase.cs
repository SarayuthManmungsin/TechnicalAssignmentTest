using Customer.Inquiry.Domain.Interface;
using System.ComponentModel.DataAnnotations;

namespace Customer.Inquiry.Domain.Implementation
{
    public abstract class DomainBase : IDomainBase
    {
        [Key]
        [MaxLength(10)]
        public virtual int Id { get; set; }
    }
}
