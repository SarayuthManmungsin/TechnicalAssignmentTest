using Customer.Inquiry.Domain.Implementation;
using Customer.Inquiry.Domain.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Customer.Inquiry.ViewModel
{
    public class CustomerViewmodel
    {
        public CustomerViewmodel()
        {
            transactions = new List<TransactionViewmodel>();
        }

        public CustomerViewmodel(IInquiryCustomer customer, IInquiryCriteria criteria)
        {
            customerID = customer.Id;
            name = customer.Name;
            email = customer.Email;
            mobile = customer.MobileNumber;

            transactions = customer.Transactions.Select(x => new TransactionViewmodel(x)).OrderByDescending(x => x.date).Take(5).ToList();
            transactions = criteria.HasAllCriteria ? transactions :
                           criteria.HasOnlyEmail ? transactions.Take(1).ToList() :
                           new List<TransactionViewmodel>();
        }

        public long customerID { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public IList<TransactionViewmodel> transactions { get; set; }

        public IInquiryCustomer Convert(CustomerViewmodel viewmodel)
        {
            return new InquiryCustomer
            {
                Email = viewmodel.email,
                MobileNumber = viewmodel.mobile,
                Transactions = viewmodel.transactions.Select(x => x.Convert()).ToList()
            };
        }
    }
}
