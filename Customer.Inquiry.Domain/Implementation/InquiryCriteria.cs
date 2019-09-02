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
    }
}
