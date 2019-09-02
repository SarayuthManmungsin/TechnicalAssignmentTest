using Customer.Inquiry.Domain.Interface;

namespace Customer.Inquiry.Domain.Implementation
{
    public class InquiryCriteria : DomainBase, IDomainBase, IInquiryCriteria
    {
        public virtual ICustomer Customer { get; set; }
        public virtual string Email { get; set; }
    }
}
