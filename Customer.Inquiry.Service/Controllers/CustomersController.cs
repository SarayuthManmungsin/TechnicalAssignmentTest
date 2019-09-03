using Customer.Inquiry.BusinessLogic.Interface;
using Customer.Inquiry.Domain.Implementation;
using Customer.Inquiry.Domain.Interface;
using Customer.Inquiry.Service.Attributes;
using Customer.Inquiry.Utils;
using Customer.Inquiry.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Customer.Inquiry.Service.Controllers
{
    // api/customers
    public class CustomersController : ApiControllerBase
    {
        private readonly ICustomerBusinessLogic _customerBusinessLogic;

        public CustomersController(ICustomerBusinessLogic customerBusinessLogic)
        {
            _customerBusinessLogic = customerBusinessLogic;
        }

        // GET api/customers
        public async Task<HttpResponseMessage> Get()
        {
            IList<IInquiryCustomer> customers = await _customerBusinessLogic.GetList();
            return CreateResponse(customers.Select(x => new CustomerViewmodel(x, new InquiryCriteria { CustomerId = 1, Email = "b" })));
        }

        // POST api/customers
        [ValidateModel]
        public async Task<HttpResponseMessage> Post(InquiryCriteriaViewmodel inquiryCriteria)
        {
            if (inquiryCriteria.customerID <= 0 && string.IsNullOrEmpty(inquiryCriteria.email))
                return CreateResponse(HttpStatusCode.BadRequest, "No inquiry criteria");
            else
            {
                if (!Validator.IsValidEmail(inquiryCriteria.email))
                    return CreateResponse(HttpStatusCode.BadRequest, "Invalid Email");
                if (!Validator.IsValidCustomerId(inquiryCriteria.customerID))
                    return CreateResponse(HttpStatusCode.BadRequest, "Invalid Customer ID");

                IInquiryCriteria criteria = inquiryCriteria.Convert();
                IInquiryCustomer customer = await _customerBusinessLogic.GetCustomer(criteria);
                if (customer == null)
                    return CreateResponse(HttpStatusCode.NotFound, "Not found");

                return CreateResponse(new CustomerViewmodel(customer, criteria));
            }
        }
    }
}