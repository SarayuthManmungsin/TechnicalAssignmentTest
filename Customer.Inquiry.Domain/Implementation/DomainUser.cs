using Customer.Inquiry.Domain.Interface;

namespace Customer.Inquiry.Domain.Implementation
{
    public abstract class DomainUser : DomainBase, IDomainBase, IDomainUser
    {
        public DomainUser()
        {
            Created = new History();
        }

        // created by other users, internal
        public DomainUser(IDomainUser user)
        {
            Created = new History(user);
        }

        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string MobileNumber { get; set; }
    }
}
