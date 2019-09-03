using Customer.Inquiry.Domain.Implementation;
using Customer.Inquiry.Domain.Interface;
using System.ComponentModel.DataAnnotations;

namespace Customer.Inquiry.ViewModel
{
    public class InquiryCriteriaViewmodel
    {
        [MaxLength(10)]
        public int? customerID;
        [MaxLength(25)]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string email;

        public IInquiryCriteria Convert()
        {
            return new InquiryCriteria
            {
                CustomerId = customerID.HasValue ? customerID.Value : -1,
                Email = email
            };
        }
    }
}
