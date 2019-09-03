using Customer.Inquiry.Domain.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer.Inquiry.Domain.Implementation
{
    public abstract class DomainUser : DomainBase, IDomainBase, IDomainUser
    { 
        [MaxLength(30)]
        public virtual string Name { get; set; }

        [Key, Column(Order = 1)]
        [MaxLength(25)]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public virtual string Email { get; set; }

        [MaxLength(10)]
        [Phone]
        public virtual string MobileNumber { get; set; }
    }
}
