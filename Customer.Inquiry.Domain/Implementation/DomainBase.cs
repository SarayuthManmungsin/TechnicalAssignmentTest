using Customer.Inquiry.Domain.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer.Inquiry.Domain.Implementation
{
    public abstract class DomainBase : IDomainBase
    {
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Range(0, 9999999999)]
        public virtual int Id { get; set; }
    }
}
