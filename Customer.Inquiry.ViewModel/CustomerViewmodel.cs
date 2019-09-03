using System.Linq;
using Customer.Inquiry.Domain.Implementation;
using Customer.Inquiry.Domain.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Customer.Inquiry.ViewModel
{
    public class CustomerViewmodel
    {
        public CustomerViewmodel()
        {
            transactions = new List<TransactionViewmodel>();
        }

        public CustomerViewmodel(IInquiryCustomer customer)
        {
            customerID = customer.Id;
            name = customer.Name;
            email = customer.Email;
            mobile = customer.MobileNumber;
            transactions = customer.Transactions.Select(x => new TransactionViewmodel(x)).ToList();
        }

        [MaxLength(10)]
        public int customerID { get; set; }

        [MaxLength(30)]
        public string name { get; set; }

        [MaxLength(25)]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string email { get; set; }

        [MaxLength(10)]
        [Phone]
        public string mobile;

        public IList<TransactionViewmodel> transactions { get; set; }

        public IInquiryCustomer Convert(CustomerViewmodel viewmodel)
        {
            return new Domain.Implementation.InquiryCustomer
            {
                Email = viewmodel.email,
                MobileNumber = viewmodel.mobile,
                Transactions = viewmodel.transactions.Select(x => x.Convert())
            };
        }
    }
}
