using Customer.Inquiry.Domain.Interface;
using System.ComponentModel.DataAnnotations;

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

        [MaxLength(30)]
        public virtual string Name { get; set; }

        [MaxLength(25)]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public virtual string ContactEmail { get; set; }

        [MaxLength(10)]
        [Phone]
        public virtual string MobileNumber { get; set; }
    }
}
