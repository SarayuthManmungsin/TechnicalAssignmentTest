using Customer.Inquiry.Domain.Interface;
using System.ComponentModel.DataAnnotations;

namespace Customer.Inquiry.Domain.Implementation
{
    public class InquiryCriteria : IInquiryCriteria
    {
        [MaxLength(10, ErrorMessage = "Invalid Customer ID")]
        public virtual int CustomerId { get; set; }
        [MaxLength(25)]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public virtual string Email { get; set; }

        public bool HasOnlyCustomerId => CustomerId > 0 && string.IsNullOrEmpty(Email);

        public bool HasOnlyEmail => CustomerId <= 0 && !string.IsNullOrEmpty(Email);

        public bool HasAllCriteria => CustomerId > 0 && !string.IsNullOrEmpty(Email);
    }
}
